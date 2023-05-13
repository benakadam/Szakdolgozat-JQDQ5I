﻿namespace Projekt.Exception;



/// <summary>
/// Bejelentkezés során előfordulható hibák
/// </summary>
[Serializable]
public class LoginException : System.Exception
{
    public LoginException() : base() { }
    public LoginException(string message) : base("Hiba a bejelentkezés során:\n" + message) { }
    public LoginException(string message, System.Exception innerException) : base(message, innerException) { }
    protected LoginException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

/// <summary>
/// Kép feldolgozása során előfordulható hibák
/// </summary>
[Serializable]
public class PythonExecuteException : System.Exception
{
    public PythonExecuteException() : base() { }
    public PythonExecuteException(string message) : base("Hiba a kép műveletek során:\n" + message) { }
    public PythonExecuteException(string message, System.Exception innerException) : base(message, innerException) { }
    protected PythonExecuteException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}


/// <summary>
/// Keresés során előfordulható hibák
/// </summary>
[Serializable]
public class SearchException : System.Exception
{
    public SearchException() : base() { }
    public SearchException(string message) : base("Hiba a keresés közben:\n" + message) { }
    public SearchException(string message, System.Exception innerException) : base(message, innerException) { }
    protected SearchException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
