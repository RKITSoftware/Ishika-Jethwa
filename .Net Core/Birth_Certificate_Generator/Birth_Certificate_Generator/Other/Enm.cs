namespace Birth_Certificate_Generator.Other
{
    /// <summary>
    /// Enum defining messages for different operations.
    /// </summary>
    public enum EnmOperation
    {
        /// <summary>
        /// Record inserted successfully.
        /// </summary>
        I,

        /// <summary>
        /// Record deleted successfully.
        /// </summary>
        D,

        /// <summary>
        /// Record updated successfully.
        /// </summary>
        U
    }
    /// <summary>
    /// Certificate Status
    /// </summary>
    public enum EnmStatus
    {
        /// <summary>
        /// Approved
        /// </summary>
        A,
        /// <summary>
        /// Pending
        /// </summary>
        P
    }
    /// <summary>
    /// Roles
    /// </summary>
    public enum EnmRoles
    {
        /// <summary>
        /// Admin
        /// </summary>
        A,
        /// <summary>
        /// User
        /// </summary>
        U

    }
}
