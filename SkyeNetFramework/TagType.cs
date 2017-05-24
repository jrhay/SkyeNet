using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkyeNet
{
    /// <summary>
    /// Enum to specify a Skyetek RFID Tag Type 
    /// </summary>
    public enum TagType : ushort
    {
        /* STPV3 Tag Types */
        AUTO_DETECT = 0x0000,

        /** ISO 15693 Tags */
        ISO_15693_AUTO_DETECT = 0x0100,
        TI_15693_AUTO_DETECT = 0x0110,
        TAGIT_HF1_PLUS = 0x0111,
        TAGIT_HF1_PRO = 0x0112,
        TAGIT_HF1_STANDARD = 0x0113,
        PHILIPS_15693_AUTO_DETECT = 0x0120,
        ICODE_SLI_SL2 = 0x0121,
        ST_15693_AUTO_DETECT = 0x0130,
        ISO_LRI64 = 0x0131,
        LRI512 = 0x0132,
        LRI2K = 0x0133,
        LRIS2K = 0x0134,
        EM_15693_AUTO_DETECT = 0x0140,
        EM4006 = 0x0141,
        EM4034 = 0x0142,
        EM4035_CRYPTO = 0x0143,
        EM4135 = 0x0144,
        INFINEON_15693_AUTO_DETECT = 0x0150,
        MYD2K = 0x0151,
        MYD2KS = 0x0152,
        MYD10K = 0x0153,
        MYD10KS = 0x0154,
        FUJITSU_AUTO_DETECT = 0x0160,
        MB89R118 = 0x0161,
        TAGSYS_15693 = 0x0170,
        TAGSYS_C370 = 0x0171,

        /** ISO 14443A Tags */
        ISO_14443A_AUTO_DETECT = 0x0200,
        PHILIPS_14443A_AUTO_DETECT = 0x0210,
        ISO_MIFARE_ULTRALIGHT = 0x0211,
        MIFARE_1K = 0x0212,
        MIFARE_4K = 0x0213,
        MIFARE_DESFIRE = 0x0214,
        MIFARE_PROX = 0x0215,
        INNOVISION_14443A_AUTO_DETECT = 0x0220,
        JEWEL = 0x0221,

        /** ISO 14443B Tags */
        ISO_14443B_AUTO_DETECT = 0x0300,
        ATMEL_14443B_AUTO_DETECT = 0x0310,
        CRYPTORF_1K = 0x0311,
        CRYPTORF_2K = 0x0312,
        CRYPTORF_4K = 0x0313,
        CRYPTORF_8K = 0x0314,
        CRYPTORF_16K = 0x0315,
        CRYPTORF_32K = 0x0316,
        CRYPTORF_64K = 0x0317,
        AT88RF001 = 0x0318,
        AT88RF020 = 0x0319,
        SAMSUNG_14443B_AUTO_DETECT = 0x0330,
        S3C89K8 = 0x0331,
        S3C89V5 = 0x0332,
        S3C89V8 = 0x0333,
        S3CC9G4 = 0x0334,
        S3CC9GC = 0x0335,
        S3CC9GW = 0x0336,
        S3CC9W4 = 0x0337,
        S3CC9W9 = 0x0338,
        ST_MICRO_14443B_AUTO_DETECT = 0x0350,
        ST_MICRO_SRIX4K = 0x0351,
        ST_MICRO_SRI176 = 0x0352,
        ST_MICRO_SRI512 = 0x0353,
        AMEX_CARD = 0x0361,
        AMEX_FOB = 0x0362,

        /** ISO 18000 Mode1 Tags */
        ISO_18000_3_MODE1_AUTO_DETECT = 0x0400,
        M1_TI_15693_AUTO_DETECT = 0x0410,
        M1_TAGIT_HF1_PLUS = 0x0411,
        M1_TAGIT_HF1_PRO = 0x0412,
        M1_TAGIT_HF1_STANDARD = 0x0413,
        M1_PHILIPS_15693_AUTO_DETECT = 0x0420,
        M1_ICODE_SLI_SL2 = 0x0421,
        M1_ST_15693_AUTO_DETECT = 0x0430,
        M1_LRI64 = 0x0431,
        M1_LRI512 = 0x0432,
        M1_EM_15693_AUTO_DETECT = 0x0440,
        M1_EM4006 = 0x0441,
        M1_EM4034 = 0x0442,
        M1_EM4035_CRYPTO = 0x0443,
        M1_EM4135 = 0x0444,
        M1_INFINEON_15693_AUTO_DETECT = 0x0450,
        M1_MYD2K = 0x0451,
        M1_MYD2KS = 0x0452,
        M1_MYD10K = 0x0453,
        M1_MYD10KS = 0x0454,

        /** Other HF Tags */
        ISO_18000_3_MODE1_EXTENDED_AUTO_DETECT = 0x0500,
        RFU = 0x0510,
        TAGSYS = 0x0511,
        ISO_18000_3_MODE2_AUTO_DETECT = 0x0600,
        INFINEON_AUTO_DETECT = 0x0610,
        INFINEON_PJM_TAG = 0x0611,
        ISO_18092_AUTO_DETECT = 0x0700,
        ISO_21481_AUTO_DETECT = 0x0800,
        HF_PROPRIETARY_RFU = 0x0900,
        TAGIT_HF = 0x0901,
        ICODE1 = 0x0902,
        HF_EPC = 0x0903,
        LTO_PHILIPS = 0x0904,
        LTO_ATMEL = 0x0905,
        FELICIA = 0x0906,
        PICOTAG_2K = 0x0907,
        PICOTAG_16K = 0x0908,
        PICOTAG_2KS = 0x0909,
        PICOTAG_16KS = 0x0910,
        HID_ICLASS = 0x0911,
        GEMWARE_C210 = 0x0912,
        GEMWARE_C220 = 0x0913,
        GEMWARE_C240 = 0x0914,
        SR176 = 0x0915,
        SKYETEK_AFE = 0x0916,
        ICODE_UID_ICS11 = 0x0917,
        ICODE_UID_ICS12 = 0x0918,

        /** EPC CLASS0 Tags */
        EPC_CLASS0_AUTO_DETECT = 0x8000,
        SYMBOL_CLASS0_AUTO_DETECT = 0x8010,
        MATRICS_CLASS0 = 0x8011,
        MATRICS_CLASS0_PLUS = 0x8012,
        IMPINJ_CLASS0_AUTO_DETECT = 0x8020,
        ZUMA = 0x8021,

        /** EPC C1 G1 Tags */
        EPC_CLASS1_GEN1_AUTO_DETECT = 0x8100,
        ALIEN_C1G1_AUTO_DETECT = 0x8110,
        QUARK = 0x8111,
        OMEGA = 0x8112,
        LEPTON = 0x8113,
        ST_MICRO_C1G1_AUTO_DETECT = 0x8120,
        XRA00 = 0x8121,

        /* EPC Class1 Gen2 */
        ISO_18000_6C_AUTO_DETECT = 0x8200,
        IMPINJ_C1G2_AUTO_DETECT = 0x8210,
        MONZA = 0x8211,
        PHILIPS_C1G2_AUTO_DETECT = 0x8220,
        UCODE_EPC_G2 = 0x8221,
        MOTOROLA_EPC_G2 = 0x8222,
        ST_C1G2_AUTO_DETECT = 0x8230,
        XRAG2 = 0x8231,
        ALIEN_HIGGS = 0x8251,
        EM_C1G2_AUTO = 0x8260,
        EM_C1G2_EM4024 = 0x8261,
        EM_C1G2_EM4124 = 0x8262,
        EM_C1G2_EM4224 = 0x8263,
        EM_C1G2_EM4324 = 0x8264,

        /** ISO 180006B Tags */
        ISO_18000_6B_AUTO_DETECT = 0x8300,
        PHILIPS_18000_6B_AUTO_DETECT = 0x8310,
        UCODE_1_19 = 0x8311,
        UCODE_HSL = 0x8312,
        FUJITSU_ISO180006B_AUTO_DETECT = 0x8320,
        FUJITSU_MB97R8010 = 0x8321,
        FUJITSU_MB97R8020 = 0x8322,

        /** ISO 180006A Tags */
        ISO_18000_6A_AUTO_DETECT = 0x8400,
        EM_6A = 0x8401,

        /** EM IPX Tags */
        EM_IPX_AUTO = 0x8500,
        EM4X22_AUTO = 0x8510,
        EM4022 = 0x8511,
        EM4122 = 0x8512,
        EM4222 = 0x8513,
        EM4X44_AUTO = 0x8520,
        EM4044 = 0x8521,
        EM4144 = 0x8522,
        EM4244 = 0x8523,
        EM4344 = 0x8524,
        EM4444 = 0x8525
    }
}
