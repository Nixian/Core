using System.Reflection;

[assembly: AssemblyTitle("Carbon.Core")]
[assembly: AssemblyProduct("Carbon")]
[assembly: AssemblyCopyright("© 2004-2012 Jason Nelson")]

[assembly: AssemblyVersion("4.0.13")]

/*
 4.0.12 (2012-08-12)
 - Changed Mime to struct w/ Type and Format properties

 4.0.12 (2012-08-05)
 - Removed TextHelper.StripXmlTags
 
 4.0.11 (2012-07-30)
 -----------------------------------------------------
 - Moved ::Media into Carbon.Media
 - Removed WindowsBase dep

 4.0.10 (2012-07-29)
 -----------------------------------------------------
 - Broke out into it's own project
 
 4.0.9 (2012-07-28)
 -----------------------------------------------------
 Scheduling::
 - Added JobState
 - Added SchedulerPolicy
 
 4.0.9 (2012-07-24)
 -----------------------------------------------------
 Cadmium -> Carbon
 
 4.0.8 (2012-07-23)
 -----------------------------------------------------
 Moved DateParser, TimeHelper, and NumberOrdinalizer to Carbon.Language
 
 4.0.7 (2012-07-20)
 -----------------------------------------------------
 - Moved Language to Carbon.Language
 - Moved Geography Helpers into Carbon.Geography
 
 4.0.6 (2012-07-10)
 -----------------------------------------------------
 - Removed Charting
 
 4.0.5 (2012-07-10)
 -----------------------------------------------------
 - Incrimented © to 2012

 : Net
 - Removed RestClient
 - Removed RestRequest
 - Removed RestResponse
 
 - Duration -> IsoDuration
 
   DateTimeExtensions
 - Added Within(DateRange period)
 - Added ToIso8601(TimeUnit precision)
 
   CollectionExtensions
 - Added Batch(Int32 batchSize)
 
   DateRange
 - Implemented Equals & GetHashCode
 
   Interval
 - Added Hourly(number)
 
 4.0.4 (2011-12-10)
 -----------------------------------------------------
 IBlobInfo, IBlobStore
 - Int64 id -> String key
 
 4.0.3 (2011-11-25)
 -----------------------------------------------------
 - Modified IMeasurement to IMeasurement<T>
 - Added Distance
 - Limit Validation Attributes to Fields and Properties
 - Added UrlAttribute
 
 4.0.2 (2011-06-20)
 -----------------------------------------------------
 . IAddress
 - Renamed State to Region
 - Rename Address1/2 to Line1/2

   QuotedPrintable
 + Decode
 
   StringExtensions
 + IsAnsi
 
   AddressExtensions
 + ToLines()
 
   IUser
 - Renamed IsMemberOfSpace to IsMemberOf 
 
   RestRequest
 + GetAsync()
 
   WebRequestExtensions
 + Async (GetRequestStream, GetResponse)
 
 - Added UserAgent
 
 :: Security
 - Replaced SignatureGenerator with Signature
 / Compute, ComputeHmacSha1, ComputeHmacSha256
 
 4.0.1 (2011-05-30)
 -----------------------------------------------------
   FileInfoExtensions
 + GetMimeType()
 
   DateTimeExtensions
 + ToIsoString
   Updated ChangePrecision to respect DateKind
   Update ToRft1123 to Convert Local Date times to UTC

   Sanitizer
 + nofollow 
 
   FileFormat
 + FromPath

 4.0.0 (2011-02-13)  [.NET 4.0]
 -----------------------------------------------------
 - Removed ErrorMessage from ValidationError
 - IUser.IsMemberOfSpace (IAgent to IContainer)

 3.5.2 (2010-12-11)
 -----------------------------------------------------
 - Added IMeasurement
 - Refactored Weight
 
 : Validation
 - Added ACSIAttribute
 - Added NumericAttribute

 3.5.1 (2010-12-11) 
 -----------------------------------------------------
 - Moved IEntity to ::Data
 - Removed depedency on Cadmium.Json
 - Removed depedency on System.Web.Abstractations
 
 3.5.0 (2009-09-01) [.NET 3.5]
 -----------------------------------------------------
 Initial Release
*/