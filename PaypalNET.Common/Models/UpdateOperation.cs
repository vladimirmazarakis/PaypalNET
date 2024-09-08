using PaypalNET.Common.Enums;

namespace PaypalNET.Common.Models
{
    /// <summary>
    /// Update operation. <see cref="UpdateOperations"/>
    /// </summary>
    public record UpdateOperation
    {
        
        public UpdateOperations Operation { get; init; }

        public UpdateOperation(UpdateOperations operation)
        {
            Operation = operation;
        }

        public string Code 
        { 
            get
            {
                return Operation.ToString().ToLower();
            } 
        }
    }
}