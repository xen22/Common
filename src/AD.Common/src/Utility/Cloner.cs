// Note: this class uses BinaryFormatter from "System.Runtime.Serialization.Formatters", which is not
// supported in NetStandard 1.6
// We can enable this when we move this library to NetStandard 2.0

// using System;
// using System.IO;
// using System.Runtime.Serialization.Formatters;


// namespace AD.Common
// {
//     public static class Cloner
//     {
//         public static T DeepClone<T>(T obj)
//         {
//             var formatter = new BinaryFormatter();
//             formatter.Context = new StreamingContext(StreamingContextStates.Clone);

//             using (var stream = new MemoryStream())
//             {
//                 formatter.Serialize(stream, obj);

//                 // reset stream
//                 stream.Position = 0;
//                 return (T)(formatter.Deserialize(stream));
//             }
//         }

//     }

// }