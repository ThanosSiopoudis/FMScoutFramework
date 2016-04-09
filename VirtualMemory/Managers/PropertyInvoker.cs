using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FMScoutFramework.Core.Entities;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Managers
{
	internal static class PropertyInvoker
	{
		public static T Get<T>(int offset, ArraySegment<byte> baseObject, int memoryAddress, DatabaseModeEnum databaseMode)
		{
			if (databaseMode == DatabaseModeEnum.Cached)
				return (T)ProcessManager.ReadFromBuffer (baseObject.Array, baseObject.Offset + offset, typeof(T));
			else { // realtime
				int offsetToFind = memoryAddress + offset;

				if (typeof(Int16) == typeof(T))
					return (T)(object)ProcessManager.ReadInt16 (offsetToFind);
				else if (typeof(Byte) == typeof(T))
					return (T)(object)ProcessManager.ReadByte (offsetToFind);
				else if (typeof(DateTime) == typeof(T))
					return (T)(object)ProcessManager.ReadDateTime (offsetToFind);
				else if (typeof(Int32) == typeof(T))
					return (T)(object)ProcessManager.ReadInt32 (offsetToFind);
				else if (typeof(SByte) == typeof(T))
					return (T)(object)ProcessManager.ReadSByte (offsetToFind);
				else if (typeof(float) == typeof(T))
					return (T)(object)ProcessManager.ReadFloat (offsetToFind);
				else if (typeof(UInt32) == typeof(T))
					return (T)(object)ProcessManager.ReadUInt32 (offsetToFind);
				else if (typeof(ushort) == typeof(T))
					return (T)(object)ProcessManager.ReadUInt16 (offsetToFind);
				else
					return default(T);
			}
		}

        public static void Set<T>(int offset, ArraySegment<byte> baseObject, int memoryAddress, DatabaseModeEnum databaseMode, T value)
        {
            if (databaseMode == DatabaseModeEnum.Cached)
            {
                throw new NotImplementedException();
            }
            else
            {
                int offsetToFind = memoryAddress + offset;

                if (typeof(Int16) == typeof(T))
                    ProcessManager.WriteInt16((int)(object)value, offsetToFind);
                else if (typeof(Byte) == typeof(T))
                    ProcessManager.WriteByte((byte)(object)value, offsetToFind);
                else if (typeof(DateTime) == typeof(T))
                    ProcessManager.WriteDateTime((DateTime)(object)value, offsetToFind);
                else if (typeof(Int32) == typeof(T))
                    ProcessManager.WriteInt32((int)(object)value, offsetToFind);
                else if (typeof(SByte) == typeof(T))
                    ProcessManager.WriteSByte((sbyte)(object)value, offsetToFind);
                else if (typeof(float) == typeof(T))
                    ProcessManager.WriteFloat((float)(object)value, offsetToFind);
                else if (typeof(UInt32) == typeof(T))
                    ProcessManager.WriteInt32((int)(object)value, offsetToFind);
                else if (typeof(ushort) == typeof(T))
                    ProcessManager.WriteInt16((short)(object)value, offsetToFind);
            }
        }


        public static string GetString(int offset, int additionalStringOffset, ArraySegment<byte> baseObject, int memoryAddress, DatabaseModeEnum databaseMode)
		{
			if (databaseMode == DatabaseModeEnum.Cached)
				return ProcessManager.ReadString (baseObject, offset, additionalStringOffset);
			else // realtime
				return ProcessManager.ReadString (memoryAddress + offset, additionalStringOffset);
		}

		private static Dictionary<Type, Func<int, IVersion, object>> pointerDelegateDictionary = new Dictionary<Type, Func<int, IVersion, object>>();
		public static T GetPointer<T>(int offset, ArraySegment<byte> baseObject, int memoryAddress, DatabaseModeEnum databaseMode, IVersion version)
			where T: class
		{
			if (databaseMode == DatabaseModeEnum.Cached) {
				int memAddress = ProcessManager.ReadInt32 (baseObject.Array, offset + baseObject.Offset);
				var objectStore = ((Dictionary<int, T>)ObjectManagerWrapper.ObjectManagers [databaseMode].ObjectStore [typeof(T)]);
				if (objectStore.ContainsKey (memAddress))
					return objectStore [memAddress] as T;
				else
					return default(T);
			} else {
				int memAddress = memoryAddress + offset;

				/*
				if (typeof(T) == typeof(Contract))
					memAddress = ProcessManager.ReadInt32 (memAddress); */

				if (!pointerDelegateDictionary.ContainsKey (typeof(T))) {
					System.Reflection.ConstructorInfo ci =
						typeof(T).GetConstructor (new[] { typeof(int), typeof(IVersion) });

					ParameterExpression memAddressParam = Expression.Parameter (typeof(int), "memAdd");
					ParameterExpression versionParam = Expression.Parameter (typeof(IVersion), "version");

					LambdaExpression lambda = Expression.Lambda (
						Expression.Convert (Expression.New (ci, memAddressParam, versionParam), typeof(object))
						, memAddressParam, versionParam);

					lock (pointerDelegateLock) {
						if (!pointerDelegateDictionary.ContainsKey (typeof(T))) {
							pointerDelegateDictionary.Add (typeof(T),
								(Func<int, IVersion, object>)lambda.Compile ());
						}
					}
				}
				return (T)pointerDelegateDictionary [typeof(T)].Invoke (ProcessManager.ReadInt32 (memAddress), version);
			}
		}

		private static object pointerDelegateLock = new object();
	}
}

