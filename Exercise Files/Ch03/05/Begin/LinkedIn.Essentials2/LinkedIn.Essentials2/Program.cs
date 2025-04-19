using Essentials2.Library;

try
{
    ExceptionSamples.ThrowExceptions(true);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw new ApplicationException("app exception", ex);
    // including the inner exception Exception ex to the new thrown exception ApplicationException
}

return;

try
{
    ExceptionSamples.ThrowExceptions(true);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

return;

try
{
    ExceptionSamples.ThrowExceptions(false);
}
catch (Exception)
{
    throw;
}

//try
//{
//    ExceptionSamples.ThrowExceptions(true);
//}
//catch (Exception ex)
//{
//    throw ex; // re-throwing this caught exception does not preserve the call stack trace information
//}
//
//try
//{
//    ExceptionSamples.ThrowExceptions(true);
//}
//catch (Exception ex)
//{
//    throw; // rethrow this exception as it was with its state without losing the call stack trace information
//}
//
//try
//{
//    ExceptionSamples.ThrowExceptions(true);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex);
//}
//
//try
//{
//    ExceptionSamples.ThrowExceptions(null);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex);
//}
return;

ExceptionSamples.BasicExceptions();
ExceptionSamples.FundamentalExceptions();
return;

CollectionSamples.Concurrent();
return;

CollectionSamples.Dictionary();
CollectionSamples.NameValue();
return;

CollectionSamples.Indexing();
CollectionSamples.Iterating();
return;

CollectionSamples.Queue();
CollectionSamples.Stack();
CollectionSamples.GenQueue();
CollectionSamples.GenStack();