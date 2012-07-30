namespace Carbon.Helpers
{
	using System.Net.Sockets;
	using System;

	using System.Threading.Tasks;

	public static class SocketExtensions
	{
		public static Task<int> ReceiveAsync(this Socket socket, byte[] buffer, int offset, int size, SocketFlags socketFlags)
		{
			var state = new TaskCompletionSource<int>(socket);

			socket.BeginReceive(buffer, offset, size, socketFlags, result => {
				var t = (TaskCompletionSource<int>)result.AsyncState;

				var s = (Socket)t.Task.AsyncState;

				try 
				{
					t.TrySetResult(s.EndReceive(result));
				}
				catch (Exception exc) 
				{ 
					t.TrySetException(exc); 
				}
			}, state);

			return state.Task;
		}
	}
}
