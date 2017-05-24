using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyeNet
{
    /// <summary>
    /// Enum to specify a status code from the SkyeTek API functions
    /// </summary>
    public enum Status : UInt16
    {
        FAILURE = 0,
        SUCCESS = 1,
        INVALID_READER,
        READER_PROTOCOL_ERROR,
        READER_IN_BOOT_LOAD_MODE,
        TAG_NOT_IN_FIELD,
        NO_TAG_ID_MATCH,
        READER_IO_ERROR,
        INVALID_PARAMETER,
        TIMEOUT,
        NOT_SUPPORTED,
        OUT_OF_MEMORY,
        COLLISION_DETECTED,
        TAG_DATA_INTEGRITY_CHECK_FAILED,
        TAG_BLOCKS_LOCKED,
        NOT_AUTHENTICATED,
        TAG_DATA_RATE_NOT_SUPPORTED,
        ENCRYPT_TAG_DATA_FAIL,
        DECRYPT_TAG_DATA_FAIL,
        INVALID_KEY_FOR_AUTHENTICATION,
        NO_APPLICATION_PRESENT,
        FILE_NOT_FOUND,
        NO_FILE_SELECTED,
        INVALID_KEY_NUMBER,
        INVALID_FILE_TYPE,
        INVALID_KEY_LENGTH,
        UNKOWN_ERROR,
        INVALID_COMMAND,
        INVALID_CRC,
        INVALID_MESSAGE_LENGTH,
        INVALID_ADDRESS,
        INVALID_FLAGS,
        INVALID_NUMBER_OF_BLOCKS,
        NO_ANTENNA_DETECTED,
        INVALID_TAG_TYPE,
        INVALID_SIGNATURE_HMAC,
        INVALID_ASCII_CHAR,
        INVALID_DATA_LEN,
        INVALID_ENCODING,
        INVALID_ARGUMENT,
        INVALID_SESSION,
        FIRMWARE_CANCELED,
        FIRMWARE_BAD_FILE,
        FIRMWARE_READER_ERROR
    }
}
