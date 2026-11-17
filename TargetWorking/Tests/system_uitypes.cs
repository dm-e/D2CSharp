using System.Uitypes;
using System;
using static System.SystemInterface;
using static System.Uitypes.UitypesInterface;
using static System_uitypes.System_uitypesImplementation;
using static System_uitypes.System_uitypesInterface;


namespace System_uitypes
{



    public class System_uitypesInterface
    {
        public static bool SUT_RunAllTests()
        {
            bool result = false;
            result = true;
            result = result & SUT_TestModalResultValues();
            result = result & SUT_TestModalResultType();
            result = result & SUT_TestPositiveResults();
            result = result & SUT_TestPositiveResultsNegativeCases();
            result = result & SUT_TestNegativeResults();
            result = result & SUT_TestNegativeResultsNegativeCases();
            result = result & SUT_TestAbortResults();
            result = result & SUT_TestAbortResultsNegativeCases();
            result = result & SUT_TestAllResults();
            result = result & SUT_TestAllResultsNegativeCases();
            result = result & SUT_TestStripAllResults();
            result = result & SUT_TestStripNormalResults();
            result = result & SUT_TestAlphaColorPrimitives();
            result = result & SUT_TestAlphaColorRgbConstants();
            result = result & SUT_TestAlphaColorSimpleConstants();
            result = result & SUT_TestAlphaColorExtendedConstants();
            result = result & SUT_TestAlphaColorNameAliases();
            result = result & SUT_TestAlphaRecordReadChannels();
            result = result & SUT_TestAlphaRecordWriteChannels();
            result = result & SUT_TestAlphaRecordModifyChannel();
            result = result & SUT_TestAlphaRecordWordOverlay();
            result = result & SUT_TestAlphaRecordCopy();
            result = result & SUT_TestAlphaColorPointer();
            result = result & SUT_TestAlphaRecordPointer();
            result = result & SUT_TestAlphaRecordSize();
            result = result & SUT_TestAlphaRecordZeroChannels();
            result = result & SUT_TestAlphaRecordAlphaChange();
            result = result & SUT_TestAlphaRecordWriteWords();
            result = result & SUT_TestAlphaRecordEachChannel();
            result = result & SUT_TestAlphaRecordChannelLimits();
            result = result & SUT_TestAlphaRecordByteOrder();
            result = result & SUT_TestAlphaRecordPointerChannels();
            result = result & SUT_TestAlphaRecordArrayCopies();
            result = result & SUT_TestAlphaRecordAliasColors();
            result = result & SUT_TestAlphaRecordLegacyColors();
            //{$IF Declared(TAlphaColorRec.ColorToRGB)}
            result = result & SUT_TestAlphaRecordColorToRGBCallback();
            //{$IFEND}
            result = result & SUT_TestAlphaRecordPalette01();
            result = result & SUT_TestAlphaRecordPalette02();
            result = result & SUT_TestAlphaRecordPalette03();
            result = result & SUT_TestAlphaRecordPalette04();
            result = result & SUT_TestAlphaRecordPalette05();
            result = result & SUT_TestAlphaRecordPalette06();
            result = result & SUT_TestAlphaRecordPalette07();
            result = result & SUT_TestAlphaRecordPalette08();
            result = result & SUT_TestAlphaRecordPalette09();
            result = result & SUT_TestAlphaRecordPalette10();
            result = result & SUT_TestAlphaRecordPalette11();
            result = result & SUT_TestAlphaRecordPalette12();
            result = result & SUT_TestAlphaRecordPalette13();
            result = result & SUT_TestAlphaRecordPalette14();
            result = result & SUT_TestAlphaRecordPalette15();
            result = result & SUT_TestAlphaRecordPalette16();
            result = result & SUT_TestAlphaRecordPalette17();
            result = result & SUT_TestColorPrimitives();
            result = result & SUT_TestColorRgbConstants();
            result = result & SUT_TestColorSimpleConstants();
            result = result & SUT_TestColorExtendedConstants();
            result = result & SUT_TestColorNameAliases();
            result = result & SUT_TestColorSystemConstants();
            result = result & SUT_TestColorSystemSpecialConstants();
            result = result & SUT_TestColorRecordReadChannels();
            result = result & SUT_TestColorRecordWriteChannels();
            result = result & SUT_TestColorRecordModifyChannel();
            result = result & SUT_TestColorRecordWordOverlay();
            result = result & SUT_TestColorRecordCopy();
            result = result & SUT_TestColorPointer();
            result = result & SUT_TestColorRecordPointer();
            result = result & SUT_TestColorVsAlphaChannelOrder();
            result = result & SUT_TestFontStyleOrdinals();
            result = result & SUT_TestFontStylesSet();
            result = result & SUT_TestFontStylesSetMutation();
            result = result & SUT_TestFontStylesSetOperators();
            result = result & SUT_TestMessageDialogTypeOrdinals();
            result = result & SUT_TestMessageDialogButtonsSet();
            result = result & SUT_TestMessageDialogButtonsMutation();
            result = result & SUT_TestAnchorKindOrdinals();
            result = result & SUT_TestAnchorsSet();
            result = result & SUT_TestBorderIconsSet();
            result = result & SUT_TestCalendarWeekDays();
            result = result & SUT_TestWindowStates();
            result = result & SUT_TestMouseButtons();
            result = result & SUT_TestEditCharCases();
            result = result & SUT_TestFontPitches();
            result = result & SUT_TestDragModes();
            result = result & SUT_TestDragKinds();
            result = result & SUT_TestDragStates();
            result = result & SUT_TestCloseActions();
            result = result & SUT_TestScrollStyles();
            result = result & SUT_TestScrollCodes();
            result = result & SUT_TestPrinterOrientations();
            result = result & SUT_TestOpenOptionsSet();
            result = result & SUT_TestOpenOptionsMutation();
            result = result & SUT_TestOpenOptionsExSet();
            result = result & SUT_TestPrintDialogOptionsSet();
            result = result & SUT_TestPageSetupDialogOptionsSet();
            result = result & SUT_TestPrinterCapabilitiesSet();
            result = result & SUT_TestFontCharsetType();
            result = result & SUT_TestImageIndexType();
            result = result & SUT_TestTabOrderType();
            result = result & SUT_TestCursorBasic();
            result = result & SUT_TestCursorSizes();
            result = result & SUT_TestCursorSpecial();
            result = result & SUT_TestDialogIdConstants();
            result = result & SUT_TestDialogIdExtended();
            result = result & SUT_TestKeyModifiers();
            result = result & SUT_TestKeyTextNavigation();
            result = result & SUT_TestKeyArrows();
            result = result & SUT_TestKeyPages();
            result = result & SUT_TestKeyEditing();
            result = result & SUT_TestKeyFunctions();
            result = result & SUT_TestKeyNumberPad();
            result = result & SUT_TestKeyArithmetic();
            result = result & SUT_TestKeyMouseButtons();
            result = result & SUT_TestKeyLocks();
            result = result & SUT_TestKeyControlSides();
            result = result & SUT_TestKeyOem();
            return result;
        }

    } // class System_uitypesInterface


    file class System_uitypesImplementation
    {


        // XE3: Some virtual-key constants are not declared in System.UITypes.
        // Use DECLARED to enable only tests for constants present in the RTL.


        // Browser and media key constants are missing in Delphi XE3.
        // The following tests are compiled only when all referenced constants exist.


        // System.UITypes uses scoped enumerations. Members are accessed via
        // TEnumType.Member, without relying on aliases from VCL units.

        // Each test returns False on failure or an exception.
        // No VCL or FireMonkey units are required.
        // Test functions are private to this unit.

        public static bool SUT_TestModalResultValues()
        {
            bool result = false;
            try
            {
                result = (mrNone == 0);
                result = result && (mrOk == 1);
                result = result && (mrCancel == 2);
                result = result && (mrAbort == 3);
                result = result && (mrRetry == 4);
                result = result && (mrIgnore == 5);
                result = result && (mrYes == 6);
                result = result && (mrNo == 7);
                result = result && (mrClose == 8);
                result = result && (mrHelp == 9);
                result = result && (mrTryAgain == 10);
                result = result && (mrContinue == 11);
                result = result && (mrAll == 12);
                result = result && (mrNoToAll == 13);
                result = result && (mrYesToAll == 14);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestModalResultType()
        {
            bool result = false;
            try
            {
                result = ((int)DelphiTypeSize.Integer == (int)DelphiTypeSize.Integer);
                result = result && (mrYes == 6);
                result = result && (mrNone == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestPositiveResults()
        {
            bool result = false;
            try
            {
                result = (IsPositiveResult(mrOk));
                result = result && (IsPositiveResult(mrYes));
                result = result && (IsPositiveResult(mrYesToAll));
                result = result && (IsPositiveResult(mrAll));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestPositiveResultsNegativeCases()
        {
            bool result = false;
            try
            {
                result = (!IsPositiveResult(mrNone));
                result = result && (!IsPositiveResult(mrNo));
                result = result && (!IsPositiveResult(mrNoToAll));
                result = result && (!IsPositiveResult(mrCancel));
                result = result && (!IsPositiveResult(mrClose));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestNegativeResults()
        {
            bool result = false;
            try
            {
                result = (IsNegativeResult(mrNo));
                result = result && (IsNegativeResult(mrNoToAll));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestNegativeResultsNegativeCases()
        {
            bool result = false;
            try
            {
                result = (!IsNegativeResult(mrNone));
                result = result && (!IsNegativeResult(mrOk));
                result = result && (!IsNegativeResult(mrYes));
                result = result && (!IsNegativeResult(mrYesToAll));
                result = result && (!IsNegativeResult(mrCancel));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAbortResults()
        {
            bool result = false;
            try
            {
                result = (IsAbortResult(mrAbort));
                result = result && (IsAbortResult(mrCancel));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAbortResultsNegativeCases()
        {
            bool result = false;
            try
            {
                result = (!IsAbortResult(mrNone));
                result = result && (!IsAbortResult(mrOk));
                result = result && (!IsAbortResult(mrYes));
                result = result && (!IsAbortResult(mrNo));
                result = result && (!IsAbortResult(mrClose));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAllResults()
        {
            bool result = false;
            try
            {
                result = (IsAnAllResult(mrAll));
                result = result && (IsAnAllResult(mrYesToAll));
                result = result && (IsAnAllResult(mrNoToAll));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAllResultsNegativeCases()
        {
            bool result = false;
            try
            {
                result = (!IsAnAllResult(mrNone));
                result = result && (!IsAnAllResult(mrOk));
                result = result && (!IsAnAllResult(mrYes));
                result = result && (!IsAnAllResult(mrNo));
                result = result && (!IsAnAllResult(mrCancel));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestStripAllResults()
        {
            bool result = false;
            try
            {
                result = (StripAllFromResult(mrAll) == mrOk);
                result = result && (StripAllFromResult(mrYesToAll) == mrYes);
                result = result && (StripAllFromResult(mrNoToAll) == mrNo);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestStripNormalResults()
        {
            bool result = false;
            try
            {
                result = (StripAllFromResult(mrNone) == mrNone);
                result = result && (StripAllFromResult(mrOk) == mrOk);
                result = result && (StripAllFromResult(mrNo) == mrNo);
                result = result && (StripAllFromResult(mrYes) == mrYes);
                result = result && (StripAllFromResult(mrCancel) == mrCancel);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaColorPrimitives()
        {
            bool result = false;
            try
            {
                result = ((int)DelphiTypeSize.Cardinal == 4);
                result = result && (TAlphaColorRec.Red == 0xFFFF0000);
                result = result && (TAlphaColorRec.Green == 0xFF008000);
                result = result && (TAlphaColorRec.Blue == 0xFF0000FF);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaColorRgbConstants()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Lime == 0xFF00FF00);
                result = result && (TAlphaColorRec.Yellow == 0xFFFFFF00);
                result = result && (TAlphaColorRec.Aqua == 0xFF00FFFF);
                result = result && (TAlphaColorRec.Fuchsia == 0xFFFF00FF);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaColorSimpleConstants()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Black == 0xFF000000);
                result = result && (TAlphaColorRec.White == 0xFFFFFFFF);
                result = result && (TAlphaColorRec.Null == 0);
                result = result && (TAlphaColorRec.Alpha == 0xFF000000);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaColorExtendedConstants()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Orange == 0xFFFFA500);
                result = result && (TAlphaColorRec.Navy == 0xFF000080);
                result = result && (TAlphaColorRec.Purple == 0xFF800080);
                result = result && (TAlphaColorRec.Coral == 0xFFFF7F50);
                result = result && (TAlphaColorRec.Silver == 0xFFC0C0C0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaColorNameAliases()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Cyan == TAlphaColorRec.Aqua);
                result = result && (TAlphaColorRec.Magenta == TAlphaColorRec.Fuchsia);
                result = result && (TAlphaColorRec.Grey == TAlphaColorRec.Gray);
                result = result && (TAlphaColorRec.Darkgrey == TAlphaColorRec.Darkgray);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // The record constructor is not available in Delphi XE3.
        // Enable this test only for RTL versions where it is documented.

        public static bool SUT_TestAlphaRecordReadChannels()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = 0xA1B2C3D4;
                result = R.A == 0xA1;
                result = result && (R.R == 0xB2);
                result = result && (R.G == 0xC3);
                result = result && (R.B == 0xD4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordWriteChannels()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = unchecked((uint)0);
                R.A = 0xAA;
                R.R = 0xBB;
                R.G = 0xCC;
                R.B = 0xDD;
                result = R.Color == 0xAABBCCDD;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordModifyChannel()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = unchecked((uint)0x10203040);
                R.G = 0x99;
                result = R.Color == unchecked((uint)0x10209940);
                result = result && (R.A == 0x10);
                result = result && (R.R == 0x20);
                result = result && (R.B == 0x40);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordWordOverlay()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = unchecked((uint)0x12345678);
                result = R.HiWord == 0x5678;
                result = result && (R.LoWord == 0x1234);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordCopy()
        {
            bool result = false;
            TAlphaColorRec A = TAlphaColorRec.CreateRecord();
            TAlphaColorRec B = TAlphaColorRec.CreateRecord();
            try
            {
                A.Color = 0xAABBCCDD;
                B = A;
                B.R = 0x11;
                result = A.Color == 0xAABBCCDD;
                result = result && (B.Color == 0xAA11CCDD);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaColorPointer()
        {
            bool result = false;
            DelphiCell<uint> C = new DelphiCell<uint>();
            Pointer<uint> P = default;
            try
            {
                C.Value = TAlphaColorRec.Red;
                P = C.AsPointer();
                result = P.Deref() == TAlphaColorRec.Red;
                P.Assign(TAlphaColorRec.Blue);
                result = result && (C.Value == TAlphaColorRec.Blue);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPointer()
        {
            bool result = false;
            DelphiCell<TAlphaColorRec> R = new DelphiCell<TAlphaColorRec>(TAlphaColorRec.CreateRecord());
            Pointer<TAlphaColorRec> P = default;
            try
            {
                TAlphaColorRec System_uitypes__0 = R.Value;

                System_uitypes__0.Color = unchecked((uint)0x11223344);
                R.Value = System_uitypes__0;
                P = R.AsPointer();
                TAlphaColorRec System_uitypes__1 = P.Deref();
                System_uitypes__1.A = 0xFE;
                P.Assign(System_uitypes__1);
                result = R.Value.Color == 0xFE223344;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Additional TAlphaColorRec tests (Delphi XE3 compatible).

        // The byte channel and word fields overlap the Color field in XE3.
        // These tests deliberately avoid TAlphaColorRec.Create (not available in XE3).

        public static bool SUT_TestAlphaRecordSize()
        {
            bool result = false;
            try
            {
                result = 4 /* SizeOf(TAlphaColorRec) */ == (int)DelphiTypeSize.Cardinal;
                result = result && (4 /* SizeOf(TAlphaColorRec) */ == 4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordZeroChannels()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = TAlphaColorRec.Null;
                result = R.A == 0;
                result = result && (R.R == 0);
                result = result && (R.G == 0);
                result = result && (R.B == 0);
                result = result && (R.HiWord == 0);
                result = result && (R.LoWord == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordAlphaChange()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = unchecked((uint)0x00123456);
                R.A = 0xEF;
                result = R.Color == 0xEF123456;
                result = result && (R.R == 0x12);
                result = result && (R.G == 0x34);
                result = result && (R.B == 0x56);
                R.A = 0;
                result = result && (R.Color == unchecked((uint)0x00123456));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordWriteWords()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = unchecked((uint)0);
                R.HiWord = 0x3344;
                R.LoWord = 0x1122;
                result = R.Color == unchecked((uint)0x11223344);
                result = result && (R.A == 0x11);
                result = result && (R.R == 0x22);
                result = result && (R.G == 0x33);
                result = result && (R.B == 0x44);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordEachChannel()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = unchecked((uint)0x10203040);
                R.B = 0xDD;
                result = R.Color == unchecked((uint)0x102030DD);
                R.G = 0xCC;
                result = result && (R.Color == unchecked((uint)0x1020CCDD));
                R.R = 0xBB;
                result = result && (R.Color == unchecked((uint)0x10BBCCDD));
                R.A = 0xAA;
                result = result && (R.Color == 0xAABBCCDD);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordChannelLimits()
        {
            bool result = false;
            TAlphaColorRec R = TAlphaColorRec.CreateRecord();
            try
            {
                R.Color = 0xFFFFFFFF;
                result = (R.A == 255);
                result = result && (R.R == 255);
                result = result && (R.G == 255);
                result = result && (R.B == 255);
                R.B = 0;
                R.G = 0;
                R.R = 0;
                R.A = 0;
                result = result && (R.Color == unchecked((uint)0));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordByteOrder()
        {
            bool result = false;
            DelphiCell<TAlphaColorRec> R = new DelphiCell<TAlphaColorRec>(TAlphaColorRec.CreateRecord());
            Pointer<byte> P = default;
            try
            {
                TAlphaColorRec System_uitypes__2 = R.Value;

                System_uitypes__2.Color = unchecked((uint)0x12345678);
                R.Value = System_uitypes__2;
                P = R.AsPointer().ToUntypedPointer().As<byte>();
                result = P.Deref() == 0x78;
                ++P;
                result = result && (P.Deref() == 0x56);
                ++P;
                result = result && (P.Deref() == 0x34);
                ++P;
                result = result && (P.Deref() == 0x12);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPointerChannels()
        {
            bool result = false;
            DelphiCell<TAlphaColorRec> R = new DelphiCell<TAlphaColorRec>(TAlphaColorRec.CreateRecord());
            Pointer<TAlphaColorRec> P = default;
            try
            {
                TAlphaColorRec System_uitypes__3 = R.Value;

                System_uitypes__3.Color = unchecked((uint)0x12345678);
                R.Value = System_uitypes__3;
                P = R.AsPointer();
                TAlphaColorRec System_uitypes__4 = P.Deref();
                System_uitypes__4.G = 0xAB;
                P.Assign(System_uitypes__4);
                result = R.Value.Color == unchecked((uint)0x1234AB78);
                TAlphaColorRec System_uitypes__5 = P.Deref();
                System_uitypes__5.A = 0xEF;
                P.Assign(System_uitypes__5);
                result = result && (R.Value.Color == 0xEF34AB78);
                result = result && (P.Deref().R == 0x34);
                result = result && (P.Deref().B == 0x78);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordArrayCopies()
        {
            bool result = false;
            TAlphaColorRec[] Items = new TAlphaColorRec[2/*# range 0..1*/];
            for (int iItems = 0; iItems < 2; iItems++)
                Items[iItems] = TAlphaColorRec.CreateRecord();
            try
            {
                Items[0].Color = unchecked((uint)0x11223344);
                Items[1].Color = unchecked((uint)0x55667788);
                Items[1] = Items[0];
                Items[1].B = 0x99;
                result = Items[0].Color == unchecked((uint)0x11223344);
                result = result && (Items[1].Color == unchecked((uint)0x11223399));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordAliasColors()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Aqua == TAlphaColorRec.Cyan);
                result = result && (TAlphaColorRec.Fuchsia == TAlphaColorRec.Magenta);
                result = result && (TAlphaColorRec.Gray == TAlphaColorRec.Grey);
                result = result && (TAlphaColorRec.Darkgray == TAlphaColorRec.Darkgrey);
                result = result && (TAlphaColorRec.Dimgray == TAlphaColorRec.Dimgrey);
                result = result && (TAlphaColorRec.Lightgray == TAlphaColorRec.Lightgrey);
                result = result && (TAlphaColorRec.Lightslategray == TAlphaColorRec.Lightslategrey);
                result = result && (TAlphaColorRec.Slategray == TAlphaColorRec.Slategrey);
                result = result && (TAlphaColorRec.Darkslategray == TAlphaColorRec.Darkslategrey);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordLegacyColors()
        {
            bool result = false;
            try
            {
                result = TAlphaColorRec.LtGray == 0xFFC0C0C0;
                result = result && (TAlphaColorRec.MedGray == 0xFFA0A0A0);
                result = result && (TAlphaColorRec.DkGray == 0xFF808080);
                result = result && (TAlphaColorRec.MoneyGreen == 0xFFC0DCC0);
                // Historical RTL revisions differ on the RGB bytes of these names.
                result = result && ((TAlphaColorRec.LegacySkyBlue & 0xFF000000) == 0xFF000000);
                result = result && ((TAlphaColorRec.Cream & 0xFF000000) == 0xFF000000);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // The callback field is optional in older System.UITypes revisions.
        //{$IF Declared(TAlphaColorRec.ColorToRGB)}
        public delegate int SUT_TAlphaColorRGBProc(uint Color);

        public static int SUT_AlphaColorRGBCallback(uint Color)
        {
            int result = 0;
            result = ((int)(Color & 0x00FFFFFF));
            return result;
        }

        public static bool SUT_TestAlphaRecordColorToRGBCallback()
        {
            bool result = false;
            SUT_TAlphaColorRGBProc OldCallback = default;
            try
            {
                OldCallback = System.DelphiDelegate.Convert<SUT_TAlphaColorRGBProc>(TAlphaColorRec.ColorToRGB);
                try
                {
                    TAlphaColorRec.ColorToRGB = SUT_AlphaColorRGBCallback;
                    result = TAlphaColorRec.ColorToRGB(0xAB102030) == 0x102030;
                }
                finally
                {
                    TAlphaColorRec.ColorToRGB = System.DelphiDelegate.Convert<UitypesDelegate1>(OldCallback);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        //{$IFEND}

        // ARGB values of the standard named colors.

        public static bool SUT_TestAlphaRecordPalette01()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Aliceblue == 0xFFF0F8FF);
                result = result && (TAlphaColorRec.Antiquewhite == 0xFFFAEBD7);
                result = result && (TAlphaColorRec.Aqua == 0xFF00FFFF);
                result = result && (TAlphaColorRec.Aquamarine == 0xFF7FFFD4);
                result = result && (TAlphaColorRec.Azure == 0xFFF0FFFF);
                result = result && (TAlphaColorRec.Beige == 0xFFF5F5DC);
                result = result && (TAlphaColorRec.Bisque == 0xFFFFE4C4);
                result = result && (TAlphaColorRec.Black == 0xFF000000);
                result = result && (TAlphaColorRec.Blanchedalmond == 0xFFFFEBCD);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette02()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Blue == 0xFF0000FF);
                result = result && (TAlphaColorRec.Blueviolet == 0xFF8A2BE2);
                result = result && (TAlphaColorRec.Brown == 0xFFA52A2A);
                result = result && (TAlphaColorRec.Burlywood == 0xFFDEB887);
                result = result && (TAlphaColorRec.Cadetblue == 0xFF5F9EA0);
                result = result && (TAlphaColorRec.Chartreuse == 0xFF7FFF00);
                result = result && (TAlphaColorRec.Chocolate == 0xFFD2691E);
                result = result && (TAlphaColorRec.Coral == 0xFFFF7F50);
                result = result && (TAlphaColorRec.Cornflowerblue == 0xFF6495ED);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette03()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Cornsilk == 0xFFFFF8DC);
                result = result && (TAlphaColorRec.Crimson == 0xFFDC143C);
                result = result && (TAlphaColorRec.Cyan == 0xFF00FFFF);
                result = result && (TAlphaColorRec.Darkblue == 0xFF00008B);
                result = result && (TAlphaColorRec.Darkcyan == 0xFF008B8B);
                result = result && (TAlphaColorRec.Darkgoldenrod == 0xFFB8860B);
                result = result && (TAlphaColorRec.Darkgray == 0xFFA9A9A9);
                result = result && (TAlphaColorRec.Darkgreen == 0xFF006400);
                result = result && (TAlphaColorRec.Darkgrey == 0xFFA9A9A9);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette04()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Darkkhaki == 0xFFBDB76B);
                result = result && (TAlphaColorRec.Darkmagenta == 0xFF8B008B);
                result = result && (TAlphaColorRec.Darkolivegreen == 0xFF556B2F);
                result = result && (TAlphaColorRec.Darkorange == 0xFFFF8C00);
                result = result && (TAlphaColorRec.Darkorchid == 0xFF9932CC);
                result = result && (TAlphaColorRec.Darkred == 0xFF8B0000);
                result = result && (TAlphaColorRec.Darksalmon == 0xFFE9967A);
                result = result && (TAlphaColorRec.Darkseagreen == 0xFF8FBC8F);
                result = result && (TAlphaColorRec.Darkslateblue == 0xFF483D8B);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette05()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Darkslategray == 0xFF2F4F4F);
                result = result && (TAlphaColorRec.Darkslategrey == 0xFF2F4F4F);
                result = result && (TAlphaColorRec.Darkturquoise == 0xFF00CED1);
                result = result && (TAlphaColorRec.Darkviolet == 0xFF9400D3);
                result = result && (TAlphaColorRec.Deeppink == 0xFFFF1493);
                result = result && (TAlphaColorRec.Deepskyblue == 0xFF00BFFF);
                result = result && (TAlphaColorRec.Dimgray == 0xFF696969);
                result = result && (TAlphaColorRec.Dimgrey == 0xFF696969);
                result = result && (TAlphaColorRec.Dodgerblue == 0xFF1E90FF);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette06()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Firebrick == 0xFFB22222);
                result = result && (TAlphaColorRec.Floralwhite == 0xFFFFFAF0);
                result = result && (TAlphaColorRec.Forestgreen == 0xFF228B22);
                result = result && (TAlphaColorRec.Fuchsia == 0xFFFF00FF);
                result = result && (TAlphaColorRec.Gainsboro == 0xFFDCDCDC);
                result = result && (TAlphaColorRec.Ghostwhite == 0xFFF8F8FF);
                result = result && (TAlphaColorRec.Gold == 0xFFFFD700);
                result = result && (TAlphaColorRec.Goldenrod == 0xFFDAA520);
                result = result && (TAlphaColorRec.Gray == 0xFF808080);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette07()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Green == 0xFF008000);
                result = result && (TAlphaColorRec.Greenyellow == 0xFFADFF2F);
                result = result && (TAlphaColorRec.Grey == 0xFF808080);
                result = result && (TAlphaColorRec.Honeydew == 0xFFF0FFF0);
                result = result && (TAlphaColorRec.Hotpink == 0xFFFF69B4);
                result = result && (TAlphaColorRec.Indianred == 0xFFCD5C5C);
                result = result && (TAlphaColorRec.Indigo == 0xFF4B0082);
                result = result && (TAlphaColorRec.Ivory == 0xFFFFFFF0);
                result = result && (TAlphaColorRec.Khaki == 0xFFF0E68C);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette08()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Lavender == 0xFFE6E6FA);
                result = result && (TAlphaColorRec.Lavenderblush == 0xFFFFF0F5);
                result = result && (TAlphaColorRec.Lawngreen == 0xFF7CFC00);
                result = result && (TAlphaColorRec.Lemonchiffon == 0xFFFFFACD);
                result = result && (TAlphaColorRec.Lightblue == 0xFFADD8E6);
                result = result && (TAlphaColorRec.Lightcoral == 0xFFF08080);
                result = result && (TAlphaColorRec.Lightcyan == 0xFFE0FFFF);
                result = result && (TAlphaColorRec.Lightgoldenrodyellow == 0xFFFAFAD2);
                result = result && (TAlphaColorRec.Lightgray == 0xFFD3D3D3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette09()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Lightgreen == 0xFF90EE90);
                result = result && (TAlphaColorRec.Lightgrey == 0xFFD3D3D3);
                result = result && (TAlphaColorRec.Lightpink == 0xFFFFB6C1);
                result = result && (TAlphaColorRec.Lightsalmon == 0xFFFFA07A);
                result = result && (TAlphaColorRec.Lightseagreen == 0xFF20B2AA);
                result = result && (TAlphaColorRec.Lightskyblue == 0xFF87CEFA);
                result = result && (TAlphaColorRec.Lightslategray == 0xFF778899);
                result = result && (TAlphaColorRec.Lightslategrey == 0xFF778899);
                result = result && (TAlphaColorRec.Lightsteelblue == 0xFFB0C4DE);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette10()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Lightyellow == 0xFFFFFFE0);
                result = result && (TAlphaColorRec.Lime == 0xFF00FF00);
                result = result && (TAlphaColorRec.Limegreen == 0xFF32CD32);
                result = result && (TAlphaColorRec.Linen == 0xFFFAF0E6);
                result = result && (TAlphaColorRec.Magenta == 0xFFFF00FF);
                result = result && (TAlphaColorRec.Maroon == 0xFF800000);
                result = result && (TAlphaColorRec.Mediumaquamarine == 0xFF66CDAA);
                result = result && (TAlphaColorRec.Mediumblue == 0xFF0000CD);
                result = result && (TAlphaColorRec.Mediumorchid == 0xFFBA55D3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette11()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Mediumpurple == 0xFF9370DB);
                result = result && (TAlphaColorRec.Mediumseagreen == 0xFF3CB371);
                result = result && (TAlphaColorRec.Mediumslateblue == 0xFF7B68EE);
                result = result && (TAlphaColorRec.Mediumspringgreen == 0xFF00FA9A);
                result = result && (TAlphaColorRec.Mediumturquoise == 0xFF48D1CC);
                result = result && (TAlphaColorRec.Mediumvioletred == 0xFFC71585);
                result = result && (TAlphaColorRec.Midnightblue == 0xFF191970);
                result = result && (TAlphaColorRec.Mintcream == 0xFFF5FFFA);
                result = result && (TAlphaColorRec.Mistyrose == 0xFFFFE4E1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette12()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Moccasin == 0xFFFFE4B5);
                result = result && (TAlphaColorRec.Navajowhite == 0xFFFFDEAD);
                result = result && (TAlphaColorRec.Navy == 0xFF000080);
                result = result && (TAlphaColorRec.Oldlace == 0xFFFDF5E6);
                result = result && (TAlphaColorRec.Olive == 0xFF808000);
                result = result && (TAlphaColorRec.Olivedrab == 0xFF6B8E23);
                result = result && (TAlphaColorRec.Orange == 0xFFFFA500);
                result = result && (TAlphaColorRec.Orangered == 0xFFFF4500);
                result = result && (TAlphaColorRec.Orchid == 0xFFDA70D6);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette13()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Palegoldenrod == 0xFFEEE8AA);
                result = result && (TAlphaColorRec.Palegreen == 0xFF98FB98);
                result = result && (TAlphaColorRec.Paleturquoise == 0xFFAFEEEE);
                result = result && (TAlphaColorRec.Palevioletred == 0xFFDB7093);
                result = result && (TAlphaColorRec.Papayawhip == 0xFFFFEFD5);
                result = result && (TAlphaColorRec.Peachpuff == 0xFFFFDAB9);
                result = result && (TAlphaColorRec.Peru == 0xFFCD853F);
                result = result && (TAlphaColorRec.Pink == 0xFFFFC0CB);
                result = result && (TAlphaColorRec.Plum == 0xFFDDA0DD);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette14()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Powderblue == 0xFFB0E0E6);
                result = result && (TAlphaColorRec.Purple == 0xFF800080);
                result = result && (TAlphaColorRec.Red == 0xFFFF0000);
                result = result && (TAlphaColorRec.Rosybrown == 0xFFBC8F8F);
                result = result && (TAlphaColorRec.Royalblue == 0xFF4169E1);
                result = result && (TAlphaColorRec.Saddlebrown == 0xFF8B4513);
                result = result && (TAlphaColorRec.Salmon == 0xFFFA8072);
                result = result && (TAlphaColorRec.Sandybrown == 0xFFF4A460);
                result = result && (TAlphaColorRec.Seagreen == 0xFF2E8B57);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette15()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Seashell == 0xFFFFF5EE);
                result = result && (TAlphaColorRec.Sienna == 0xFFA0522D);
                result = result && (TAlphaColorRec.Silver == 0xFFC0C0C0);
                result = result && (TAlphaColorRec.Skyblue == 0xFF87CEEB);
                result = result && (TAlphaColorRec.Slateblue == 0xFF6A5ACD);
                result = result && (TAlphaColorRec.Slategray == 0xFF708090);
                result = result && (TAlphaColorRec.Slategrey == 0xFF708090);
                result = result && (TAlphaColorRec.Snow == 0xFFFFFAFA);
                result = result && (TAlphaColorRec.Springgreen == 0xFF00FF7F);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette16()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Steelblue == 0xFF4682B4);
                result = result && (TAlphaColorRec.Tan == 0xFFD2B48C);
                result = result && (TAlphaColorRec.Teal == 0xFF008080);
                result = result && (TAlphaColorRec.Thistle == 0xFFD8BFD8);
                result = result && (TAlphaColorRec.Tomato == 0xFFFF6347);
                result = result && (TAlphaColorRec.Turquoise == 0xFF40E0D0);
                result = result && (TAlphaColorRec.Violet == 0xFFEE82EE);
                result = result && (TAlphaColorRec.Wheat == 0xFFF5DEB3);
                result = result && (TAlphaColorRec.White == 0xFFFFFFFF);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAlphaRecordPalette17()
        {
            bool result = false;
            try
            {
                result = (TAlphaColorRec.Whitesmoke == 0xFFF5F5F5);
                result = result && (TAlphaColorRec.Yellow == 0xFFFFFF00);
                result = result && (TAlphaColorRec.Yellowgreen == 0xFF9ACD32);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorPrimitives()
        {
            bool result = false;
            try
            {
                result = ((int)DelphiTypeSize.Integer == (int)DelphiTypeSize.Integer);
                result = result && (unchecked((uint)TColorRec.Red) == 0x000000FF);
                result = result && (unchecked((uint)TColorRec.Green) == 0x00008000);
                result = result && (unchecked((uint)TColorRec.Blue) == 0x00FF0000);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRgbConstants()
        {
            bool result = false;
            try
            {
                result = (unchecked((uint)TColorRec.Lime) == 0x0000FF00);
                result = result && (unchecked((uint)TColorRec.Yellow) == 0x0000FFFF);
                result = result && (unchecked((uint)TColorRec.Aqua) == 0x00FFFF00);
                result = result && (unchecked((uint)TColorRec.Fuchsia) == 0x00FF00FF);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorSimpleConstants()
        {
            bool result = false;
            try
            {
                result = (unchecked((uint)TColorRec.Black) == 0);
                result = result && (unchecked((uint)TColorRec.White) == 0x00FFFFFF);
                result = result && (unchecked((uint)TColorRec.Gray) == 0x00808080);
                result = result && (unchecked((uint)TColorRec.Null) == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorExtendedConstants()
        {
            bool result = false;
            try
            {
                result = (unchecked((uint)TColorRec.Orange) == 0x0000A5FF);
                result = result && (unchecked((uint)TColorRec.Navy) == 0x00800000);
                result = result && (unchecked((uint)TColorRec.Purple) == 0x00800080);
                result = result && (unchecked((uint)TColorRec.Coral) == 0x00507FFF);
                result = result && (unchecked((uint)TColorRec.Silver) == 0x00C0C0C0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorNameAliases()
        {
            bool result = false;
            try
            {
                result = (TColorRec.Cyan == TColorRec.Aqua);
                result = result && (TColorRec.Magenta == TColorRec.Fuchsia);
                result = result && (TColorRec.Grey == TColorRec.Gray);
                result = result && (TColorRec.Darkgrey == TColorRec.Darkgray);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorSystemConstants()
        {
            bool result = false;
            try
            {
                result = (TColorRec.SystemColor == 0xFF000000);
                result = result && (unchecked((uint)TColorRec.SysWindow) == 0xFF000005);
                result = result && (unchecked((uint)TColorRec.SysHighlight) == 0xFF00000D);
                result = result && (unchecked((uint)TColorRec.SysBtnFace) == 0xFF00000F);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorSystemSpecialConstants()
        {
            bool result = false;
            try
            {
                result = (unchecked((uint)TColorRec.SysNone) == 0x1FFFFFFF);
                result = result && (unchecked((uint)TColorRec.SysDefault) == 0x20000000);
                result = result && (TColorRec.cWINDOW == 5);
                result = result && (TColorRec.cHIGHLIGHT == 13);
                result = result && (TColorRec.cBTNFACE == 15);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRecordReadChannels()
        {
            bool result = false;
            TColorRec R = TColorRec.CreateRecord();
            try
            {
                R.Color = 0x00112233;
                result = R.R == 0x33;
                result = result && (R.G == 0x22);
                result = result && (R.B == 0x11);
                result = result && (R.A == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRecordWriteChannels()
        {
            bool result = false;
            TColorRec R = TColorRec.CreateRecord();
            try
            {
                R.Color = 0;
                R.R = 0x11;
                R.G = 0x22;
                R.B = 0x33;
                R.A = 0;
                result = unchecked((uint)R.Color) == 0x00332211;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRecordModifyChannel()
        {
            bool result = false;
            TColorRec R = TColorRec.CreateRecord();
            try
            {
                R.Color = 0x00112233;
                R.G = 0x99;
                result = unchecked((uint)R.Color) == 0x00119933;
                result = result && (R.R == 0x33);
                result = result && (R.B == 0x11);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRecordWordOverlay()
        {
            bool result = false;
            TColorRec R = TColorRec.CreateRecord();
            try
            {
                R.Color = 0x12345678;
                result = R.HiWord == 0x5678;
                result = result && (R.LoWord == 0x1234);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRecordCopy()
        {
            bool result = false;
            TColorRec A = TColorRec.CreateRecord();
            TColorRec B = TColorRec.CreateRecord();
            try
            {
                A.Color = 0x00112233;
                B = A;
                B.B = 0x77;
                result = unchecked((uint)A.Color) == 0x00112233;
                result = result && (unchecked((uint)B.Color) == 0x00772233);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorPointer()
        {
            bool result = false;
            DelphiCell<int> C = new DelphiCell<int>();
            Pointer<int> P = default;
            try
            {
                C.Value = TColorRec.Red;
                P = C.AsPointer();
                result = P.Deref() == TColorRec.Red;
                P.Assign(TColorRec.Blue);
                result = result && (C.Value == TColorRec.Blue);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorRecordPointer()
        {
            bool result = false;
            DelphiCell<TColorRec> R = new DelphiCell<TColorRec>(TColorRec.CreateRecord());
            Pointer<TColorRec> P = default;
            try
            {
                TColorRec System_uitypes__6 = R.Value;

                System_uitypes__6.Color = 0x00112233;
                R.Value = System_uitypes__6;
                P = R.AsPointer();
                TColorRec System_uitypes__7 = P.Deref();
                System_uitypes__7.R = 0xAA;
                P.Assign(System_uitypes__7);
                result = unchecked((uint)R.Value.Color) == 0x001122AA;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestColorVsAlphaChannelOrder()
        {
            bool result = false;
            try
            {
                result = (unchecked((uint)TColorRec.Red) == 0x000000FF);
                result = result && (TAlphaColorRec.Red == 0xFFFF0000);
                result = result && (unchecked((uint)TColorRec.Blue) == 0x00FF0000);
                result = result && (TAlphaColorRec.Blue == 0xFF0000FF);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestFontStyleOrdinals()
        {
            bool result = false;
            try
            {
                result = ((int)(TFontStyle.fsBold) == 0);
                result = result && ((int)(TFontStyle.fsItalic) == 1);
                result = result && ((int)(TFontStyle.fsUnderline) == 2);
                result = result && ((int)(TFontStyle.fsStrikeOut) == 3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestFontStylesSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TFontStyle.fsBold << (int)TFontStyle.fsUnderline);
                result = S.Contains((int)(TFontStyle.fsBold));
                result = result && (S.Contains((int)(TFontStyle.fsUnderline)));
                result = result && !(S.Contains((int)(TFontStyle.fsItalic)));
                result = result && !(S.Contains((int)(TFontStyle.fsStrikeOut)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestFontStylesSetMutation()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet());
                S = S << (int)TFontStyle.fsItalic;
                S = S << (int)TFontStyle.fsStrikeOut;
                S = S >> (int)TFontStyle.fsItalic;
                result = S.Contains((int)(TFontStyle.fsStrikeOut));
                result = result && !(S.Contains((int)(TFontStyle.fsItalic)));
                result = result && (S == ((new TSet() << (int)TFontStyle.fsStrikeOut)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestFontStylesSetOperators()
        {
            bool result = false;
            TSet A = new TSet();
            TSet B = new TSet();
            TSet C = new TSet();
            try
            {
                A = (new TSet() << (int)TFontStyle.fsBold << (int)TFontStyle.fsItalic);
                B = (new TSet() << (int)TFontStyle.fsItalic << (int)TFontStyle.fsUnderline);
                C = A + B;
                result = C == ((new TSet() << (int)TFontStyle.fsBold << (int)TFontStyle.fsItalic << (int)TFontStyle.fsUnderline));
                C = A * B;
                result = result && (C == ((new TSet() << (int)TFontStyle.fsItalic)));
                C = A - B;
                result = result && (C == ((new TSet() << (int)TFontStyle.fsBold)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestMessageDialogTypeOrdinals()
        {
            bool result = false;
            try
            {
                result = ((int)(TMsgDlgType.mtWarning) == 0);
                result = result && ((int)(TMsgDlgType.mtError) == 1);
                result = result && ((int)(TMsgDlgType.mtInformation) == 2);
                result = result && ((int)(TMsgDlgType.mtConfirmation) == 3);
                result = result && ((int)(TMsgDlgType.mtCustom) == 4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestMessageDialogButtonsSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TMsgDlgBtn.mbYes << (int)TMsgDlgBtn.mbNo << (int)TMsgDlgBtn.mbCancel);
                result = S.Contains((int)(TMsgDlgBtn.mbYes));
                result = result && (S.Contains((int)(TMsgDlgBtn.mbNo)));
                result = result && (S.Contains((int)(TMsgDlgBtn.mbCancel)));
                result = result && !(S.Contains((int)(TMsgDlgBtn.mbOK)));
                result = result && !(S.Contains((int)(TMsgDlgBtn.mbHelp)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestMessageDialogButtonsMutation()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TMsgDlgBtn.mbYes << (int)TMsgDlgBtn.mbNo);
                S = S << (int)TMsgDlgBtn.mbHelp;
                S = S >> (int)TMsgDlgBtn.mbNo;
                result = S == ((new TSet() << (int)TMsgDlgBtn.mbYes << (int)TMsgDlgBtn.mbHelp));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAnchorKindOrdinals()
        {
            bool result = false;
            try
            {
                result = ((int)(TAnchorKind.akLeft) == 0);
                result = result && ((int)(TAnchorKind.akTop) == 1);
                result = result && ((int)(TAnchorKind.akRight) == 2);
                result = result && ((int)(TAnchorKind.akBottom) == 3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestAnchorsSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TAnchorKind.akLeft << (int)TAnchorKind.akTop);
                result = S.Contains((int)(TAnchorKind.akLeft));
                result = result && (S.Contains((int)(TAnchorKind.akTop)));
                result = result && !(S.Contains((int)(TAnchorKind.akRight)));
                S = S << (int)TAnchorKind.akBottom;
                result = result && (S.Contains((int)(TAnchorKind.akBottom)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestBorderIconsSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TBorderIcon.biSystemMenu << (int)TBorderIcon.biMinimize);
                result = S.Contains((int)(TBorderIcon.biSystemMenu));
                result = result && (S.Contains((int)(TBorderIcon.biMinimize)));
                result = result && !(S.Contains((int)(TBorderIcon.biMaximize)));
                S = S << (int)TBorderIcon.biHelp;
                result = result && (S.Contains((int)(TBorderIcon.biHelp)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestCalendarWeekDays()
        {
            bool result = false;
            try
            {
                result = ((int)(TCalDayOfWeek.dowMonday) == 0);
                result = result && ((int)(TCalDayOfWeek.dowTuesday) == 1);
                result = result && ((int)(TCalDayOfWeek.dowSunday) == 6);
                result = result && ((int)(TCalDayOfWeek.dowLocaleDefault) == 7);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestWindowStates()
        {
            bool result = false;
            try
            {
                result = ((int)(TWindowState.wsNormal) == 0);
                result = result && ((int)(TWindowState.wsMinimized) == 1);
                result = result && ((int)(TWindowState.wsMaximized) == 2);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestMouseButtons()
        {
            bool result = false;
            try
            {
                result = ((int)(TMouseButton.mbLeft) == 0);
                result = result && ((int)(TMouseButton.mbRight) == 1);
                result = result && ((int)(TMouseButton.mbMiddle) == 2);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestEditCharCases()
        {
            bool result = false;
            try
            {
                result = ((int)(TEditCharCase.ecNormal) == 0);
                result = result && ((int)(TEditCharCase.ecUpperCase) == 1);
                result = result && ((int)(TEditCharCase.ecLowerCase) == 2);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestFontPitches()
        {
            bool result = false;
            try
            {
                result = ((int)(TFontPitch.fpDefault) == 0);
                result = result && ((int)(TFontPitch.fpVariable) == 1);
                result = result && ((int)(TFontPitch.fpFixed) == 2);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestDragModes()
        {
            bool result = false;
            try
            {
                result = ((int)(TDragMode.dmManual) == 0);
                result = result && ((int)(TDragMode.dmAutomatic) == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestDragKinds()
        {
            bool result = false;
            try
            {
                result = ((int)(TDragKind.dkDrag) == 0);
                result = result && ((int)(TDragKind.dkDock) == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestDragStates()
        {
            bool result = false;
            try
            {
                result = ((int)(TDragState.dsDragEnter) == 0);
                result = result && ((int)(TDragState.dsDragLeave) == 1);
                result = result && ((int)(TDragState.dsDragMove) == 2);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestCloseActions()
        {
            bool result = false;
            try
            {
                result = ((int)(TCloseAction.caNone) == 0);
                result = result && ((int)(TCloseAction.caHide) == 1);
                result = result && ((int)(TCloseAction.caFree) == 2);
                result = result && ((int)(TCloseAction.caMinimize) == 3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestScrollStyles()
        {
            bool result = false;
            try
            {
                result = ((int)(TScrollStyle.ssNone) == 0);
                result = result && ((int)(TScrollStyle.ssHorizontal) == 1);
                result = result && ((int)(TScrollStyle.ssVertical) == 2);
                result = result && ((int)(TScrollStyle.ssBoth) == 3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestScrollCodes()
        {
            bool result = false;
            try
            {
                result = ((int)(TScrollCode.scLineUp) == 0);
                result = result && ((int)(TScrollCode.scLineDown) == 1);
                result = result && ((int)(TScrollCode.scPageUp) == 2);
                result = result && ((int)(TScrollCode.scPageDown) == 3);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestPrinterOrientations()
        {
            bool result = false;
            try
            {
                result = ((int)(TPrinterOrientation.poPortrait) == 0);
                result = result && ((int)(TPrinterOrientation.poLandscape) == 1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestOpenOptionsSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TOpenOption.ofReadOnly << (int)TOpenOption.ofFileMustExist << (int)TOpenOption.ofAllowMultiSelect);
                result = S.Contains((int)(TOpenOption.ofReadOnly));
                result = result && (S.Contains((int)(TOpenOption.ofFileMustExist)));
                result = result && (S.Contains((int)(TOpenOption.ofAllowMultiSelect)));
                result = result && !(S.Contains((int)(TOpenOption.ofNoValidate)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestOpenOptionsMutation()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TOpenOption.ofPathMustExist);
                S = S << (int)TOpenOption.ofNoChangeDir;
                S = S >> (int)TOpenOption.ofPathMustExist;
                result = S == ((new TSet() << (int)TOpenOption.ofNoChangeDir));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestOpenOptionsExSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TOpenOptionEx.ofExNoPlacesBar);
                result = S.Contains((int)(TOpenOptionEx.ofExNoPlacesBar));
                S = (new TSet());
                result = result && !(S.Contains((int)(TOpenOptionEx.ofExNoPlacesBar)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestPrintDialogOptionsSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TPrintDialogOption.poPrintToFile << (int)TPrintDialogOption.poPageNums << (int)TPrintDialogOption.poSelection);
                result = S.Contains((int)(TPrintDialogOption.poPrintToFile));
                result = result && (S.Contains((int)(TPrintDialogOption.poPageNums)));
                result = result && (S.Contains((int)(TPrintDialogOption.poSelection)));
                result = result && !(S.Contains((int)(TPrintDialogOption.poWarning)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestPageSetupDialogOptionsSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TPageSetupDialogOption.psoMargins << (int)TPageSetupDialogOption.psoMinMargins << (int)TPageSetupDialogOption.psoShowHelp);
                result = S.Contains((int)(TPageSetupDialogOption.psoMargins));
                result = result && (S.Contains((int)(TPageSetupDialogOption.psoMinMargins)));
                result = result && (S.Contains((int)(TPageSetupDialogOption.psoShowHelp)));
                result = result && !(S.Contains((int)(TPageSetupDialogOption.psoWarning)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestPrinterCapabilitiesSet()
        {
            bool result = false;
            TSet S = new TSet();
            try
            {
                S = (new TSet() << (int)TPrinterCapability.pcCopies << (int)TPrinterCapability.pcOrientation);
                result = S.Contains((int)(TPrinterCapability.pcCopies));
                result = result && (S.Contains((int)(TPrinterCapability.pcOrientation)));
                result = result && !(S.Contains((int)(TPrinterCapability.pcCollation)));
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestFontCharsetType()
        {
            bool result = false;
            byte C = 0;
            try
            {
                C = unchecked((byte)204);
                result = (int)(C) == 204;
                C = unchecked((byte)0);
                result = result && ((int)(C) == 0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestImageIndexType()
        {
            bool result = false;
            int N = 0;
            try
            {
                N = -1;
                result = N == -1;
                N = 1234;
                result = result && (N == 1234);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestTabOrderType()
        {
            bool result = false;
            int N = 0;
            try
            {
                N = 7;
                result = N == 7;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestCursorBasic()
        {
            bool result = false;
            try
            {
                result = (crDefault == 0);
                result = result && (crNone == -1);
                result = result && (crArrow == -2);
                result = result && (crCross == -3);
                result = result && (crIBeam == -4);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestCursorSizes()
        {
            bool result = false;
            try
            {
                result = (crSizeNESW == -6);
                result = result && (crSizeNS == -7);
                result = result && (crSizeNWSE == -8);
                result = result && (crSizeWE == -9);
                result = result && (crUpArrow == -10);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestCursorSpecial()
        {
            bool result = false;
            try
            {
                result = (crHourGlass == -11);
                result = result && (crNoDrop == -13);
                result = result && (crHandPoint == -21);
                result = result && (crSizeAll == crSize);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestDialogIdConstants()
        {
            bool result = false;
            try
            {
                result = (idOK == 1);
                result = result && (idCancel == 2);
                result = result && (idAbort == 3);
                result = result && (idRetry == 4);
                result = result && (idIgnore == 5);
                result = result && (idNo == 7);
                result = result && (idClose == 8);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestDialogIdExtended()
        {
            bool result = false;
            try
            {
                result = (idHelp == 9);
                result = result && (idTryAgain == 10);
                result = result && (idContinue == 11);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyModifiers()
        {
            bool result = false;
            try
            {
                result = (vkShift == 0x10);
                result = result && (vkControl == 0x11);
                result = result && (vkMenu == 0x12);
                result = result && (vkCapital == 0x14);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyTextNavigation()
        {
            bool result = false;
            try
            {
                result = (vkBack == 8);
                result = result && (vkTab == 9);
                result = result && (vkReturn == 0x0D);
                result = result && (vkEscape == 0x1B);
                result = result && (vkSpace == 0x20);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyArrows()
        {
            bool result = false;
            try
            {
                result = (vkLeft == 0x25);
                result = result && (vkUp == 0x26);
                result = result && (vkRight == 0x27);
                result = result && (vkDown == 0x28);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyPages()
        {
            bool result = false;
            try
            {
                result = (vkPrior == 0x21);
                result = result && (vkNext == 0x22);
                result = result && (vkEnd == 0x23);
                result = result && (vkHome == 0x24);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyEditing()
        {
            bool result = false;
            try
            {
                result = (vkInsert == 0x2D);
                result = result && (vkDelete == 0x2E);
                result = result && (vkSnapshot == 0x2C);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyFunctions()
        {
            bool result = false;
            try
            {
                result = (vkF1 == 0x70);
                result = result && (vkF2 == 0x71);
                result = result && (vkF10 == 0x79);
                result = result && (vkF12 == 0x7B);
                result = result && (vkF24 == 0x87);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyNumberPad()
        {
            bool result = false;
            try
            {
                result = (vkNumpad0 == 0x60);
                result = result && (vkNumpad1 == 0x61);
                result = result && (vkNumpad9 == 0x69);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyArithmetic()
        {
            bool result = false;
            try
            {
                result = (vkMultiply == 0x6A);
                result = result && (vkAdd == 0x6B);
                result = result && (vkSubtract == 0x6D);
                result = result && (vkDecimal == 0x6E);
                result = result && (vkDivide == 0x6F);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyMouseButtons()
        {
            bool result = false;
            try
            {
                result = (vkLButton == 1);
                result = result && (vkRButton == 2);
                result = result && (vkMButton == 4);
                result = result && (vkXButton1 == 5);
                result = result && (vkXButton2 == 6);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyLocks()
        {
            bool result = false;
            try
            {
                result = (vkNumLock == 0x90);
                result = result && (vkScroll == 0x91);
                result = result && (vkLShift == 0xA0);
                result = result && (vkRShift == 0xA1);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyControlSides()
        {
            bool result = false;
            try
            {
                result = (vkLControl == 0xA2);
                result = result && (vkRControl == 0xA3);
                result = result && (vkLMenu == 0xA4);
                result = result && (vkRMenu == 0xA5);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool SUT_TestKeyOem()
        {
            bool result = false;
            try
            {
                result = (vkSemicolon == 0xBA);
                result = result && (vkEqual == 0xBB);
                result = result && (vkComma == 0xBC);
                result = result && (vkMinus == 0xBD);
                result = result && (vkSlash == 0xBF);
                result = result && (vkTilde == 0xC0);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /*$B+*/
        /*$B-*/
    } // class System_uitypesImplementation

}  // namespace System_uitypes

