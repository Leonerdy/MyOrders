using System;
using Plugin.SecureStorage;

namespace MyOrders.Droid
{
    public static class LinkerPreserve
    {
        static LinkerPreserve()
        {
            throw new Exception(typeof(SecureStorageImplementation).FullName);
        }
    }

    public class PreserveAttribute : Attribute
    {
    }


}