﻿using System.ComponentModel;

namespace ClassLibraryCommon
{

    public enum RadioPanelPZ69Display
    {
        Active,
        Standby,
        UpperActive,
        UpperStandby,
        LowerActive,
        LowerStandby
    }

    public enum KeyPressLength
    {
        //Zero = 0, <-- DCS & keybd_event does not work without delay between key press & release
        Indefinite = 999999999,
        FiftyMilliSec = 50,
        HalfSecond = 500,
        Second = 1000,
        SecondAndHalf = 1500,
        TwoSeconds = 2000,
        ThreeSeconds = 3000,
        FourSeconds = 4000,
        FiveSecs = 5000,
        TenSecs = 10000,
        FifteenSecs = 15000,
        TwentySecs = 20000,
        ThirtySecs = 30000,
        FortySecs = 40000,
        SixtySecs = 60000
    }

    public enum APIModeEnum
    {
        keybd_event = 0,
        SendInput = 1
    }
    /*
    public enum GamingPanelEnum
    {
        Unknown = 0,
        PZ55SwitchPanel = 2,
        PZ69RadioPanel = 4,
        PZ70MultiPanel = 8,
        BackLitPanel = 16,
        TPM = 32,
        StreamDeck23 = 64,
        StreamDeck35 = 128,
        StreamDeck48 = 256
    }
    */
    public enum GamingPanelVendorsEnum
    {
        Unknown = 0,
        Saitek = 0x6A3,
        Elgato = 0xFD9
    }

    public enum GamingPanelEnum
    {
        Unknown = 0,
        PZ55SwitchPanel = 0xD67,
        PZ69RadioPanel = 0xD05,
        PZ70MultiPanel = 0xD06,
        BackLitPanel = 0xB4E,
        TPM = 0xB4D,
        StreamDeck23 = 0x0063,
        StreamDeck35 = 0x0060,
        StreamDeck48 = 0x006C
    }

/*
 * Keyemulator
 * DCS-BIOS Profile
 * Radios : DCS-BIOS || SRS
 */

/*
 * Description = What is defined (XYZ) in BIOS.protocol.setExportModuleAircrafts({"XYZ"})
 * Value => not used
 */
public enum DCSAirframe
{
    [Description("NoFrameLoadedYet")]
    NOFRAMELOADEDYET,
    [Description("KeyEmulator")]
    KEYEMULATOR,
    [Description("KeyEmulator_SRS")]
    KEYEMULATOR_SRS,
    [Description("A-4E-C")]
    A4E,
    [Description("A-10C")]
    A10C,
    [Description("AJS37")]
    AJS37,
    [Description("AV8BNA")]
    AV8BNA,
    [Description("Bf-109K-4")]
    Bf109,
    [Description("C-101CC")]
    C101CC,
    [Description("Christen Eagle II")]
    ChristenEagle,
    [Description("F-5E-3")]
    F5E,
    [Description("F-14B")]
    F14B,
    [Description("FA-18C_hornet")]
    FA18C,
    [Description("F-86F Sabre")]
    F86F,
    [Description("FC3-CD-SRS")]
    FC3_CD_SRS,
    [Description("FW-190A8")]
    Fw190a8,
    [Description("FW-190D9")]
    Fw190d9,
    [Description("I-16")]
    I16,
    [Description("Ka-50")]
    Ka50,
    [Description("L-39ZA")]
    L39ZA,
    [Description("M-2000C")]
    M2000C,
    [Description("MB-339PAN")]
    MB339,
    [Description("Mi-8MT")]
    Mi8,
    [Description("MiG-15bis")]
    Mig15bis,
    [Description("MiG-19P")]
    Mig19P,
    [Description("MiG-21Bis")]
    Mig21Bis,
    [Description("NS430")]
    NS430,
    [Description("P-51D")]
    P51D,
    [Description("SA342M")]
    SA342M,
    [Description("SpitfireLFMkIX")]
    SpitfireLFMkIX,
    [Description("UH-1H")]
    UH1H,
    [Description("Yak-52")]
    Yak52
}

class CommonEnums
{
}
}
