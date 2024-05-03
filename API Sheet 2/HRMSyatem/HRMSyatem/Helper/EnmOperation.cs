namespace HRMSystem.Helper
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
    /// Enum defining Role of the User
    /// </summary>
    public enum EnmRole
    {
        /// <summary>
        /// For HR
        /// </summary>
        HR,

        /// <summary>
        /// For Employee
        /// </summary>
        EMP
    }

    /// <summary>
    /// Enum Definig Status of Leave
    /// </summary>
    public enum EnmStatus
    {
        /// <summary>
        /// Approve
        /// </summary>
        A , 
        /// <summary>
        /// Pending
        /// </summary>
        P ,
        /// <summary>
        /// Rejected
        /// </summary>
        R
    }
  
}