using System;
using System.Runtime.Serialization;

namespace NCore.Samples.Inventory.Domain.Aggregates.InventoryItem.Exceptions
{
    [Serializable]
    public class InventoryItemAlreadyExistsException : Exception
    {
        public InventoryItemAlreadyExistsException(string key)
            : base($"Inventory item with key '{key}' already exists.")
        {
        }

        protected InventoryItemAlreadyExistsException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
    [Serializable]
    public class InventoryItemCannotBeActivatedException : Exception
    {
        public InventoryItemCannotBeActivatedException(string key, string currentState)
            : base($"Inventory item with key '{key}' cannot be activated. It's current state is '{currentState}'.")
        {
        }

        protected InventoryItemCannotBeActivatedException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}