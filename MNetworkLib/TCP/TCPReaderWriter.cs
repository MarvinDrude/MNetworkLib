using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MNetworkLib.TCP {

    /// <summary>
    /// Helper to write and read stuff off a stream
    /// </summary>
    public static class TCPReaderWriter {

        public static void WriteNumber(Stream stream, int number, bool littleEndian) {
            
            byte[] buffer = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian && !littleEndian) {

                Array.Reverse(buffer);

            }

            stream.Write(buffer, 0, buffer.Length);

        }

        public static void WriteNumber(Stream stream, long number, bool littleEndian) {

            byte[] buffer = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian && !littleEndian) {

                Array.Reverse(buffer);

            }

            stream.Write(buffer, 0, buffer.Length);

        }

        public static void WriteNumber(Stream stream, ulong number, bool littleEndian) {

            byte[] buffer = BitConverter.GetBytes(number);

            if (BitConverter.IsLittleEndian && !littleEndian) {

                Array.Reverse(buffer);

            }

            stream.Write(buffer, 0, buffer.Length);

        }

        public static ushort ReadUShort(Stream stream, bool littleEndian) {

            byte[] buffer = Read(stream, 2);

            if (!littleEndian) {

                Array.Reverse(buffer);

            }

            return BitConverter.ToUInt16(buffer, 0);

        }

        public static ulong ReadULong(Stream stream, bool littleEndian) {

            byte[] buffer = Read(stream, 8);

            if (!littleEndian) {

                Array.Reverse(buffer);

            }

            return BitConverter.ToUInt64(buffer, 0);

        }

        public static long ReadLong(Stream stream, bool littleEndian) {

            byte[] buffer = Read(stream, 8);

            if (!littleEndian) {

                Array.Reverse(buffer);

            }

            return BitConverter.ToInt64(buffer, 0);

        }

        public static byte[] Read(Stream stream, uint len) {

            byte[] buffer = new byte[len];
            int read = 0;

            read = stream.Read(buffer, 0, buffer.Length);

            if (read < len) {

                return null;

            }

            return buffer;

        }

    }
}
