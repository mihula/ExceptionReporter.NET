namespace ExceptionReporting
{
    /// <summary>
    /// The assembly version type to extract from the main application assembly
    /// </summary>
    public enum AssemblyVersionType
    {
        /// <summary>
        /// AssemblyVersion attribute (the base version number)
        /// </summary>
        AssemblyVersion,

        /// <summary>
        /// FileVersion attribute (the version assigned to the DLL/EXE file itself)
        /// </summary>
        FileVersion,

        /// <summary>
        /// InformationalVersion attribute (human-readable product version)
        /// </summary>
        InformationalVersion
    }
}
