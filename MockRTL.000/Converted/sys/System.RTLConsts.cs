using System;
using static System.Rtlconsts.RtlconstsImplementation;
using static System.Rtlconsts.RtlconstsInterface;
using static System.SystemInterface;

namespace System
{

namespace Rtlconsts
{

/*
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of selected
  System.RTLConsts resource strings required by D2CSharp.

  The identifiers are provided so that D2CSharp can resolve references from
  RTL units such as System.StrUtils. The message texts are independently
  written placeholders and are not copies of the Delphi RTL resource texts.

  Copyright (c) 2026 Dr. Detlef Meyer-Eltz, t2t-soft
  SPDX-License-Identifier: Apache-2.0

  Licensed under the Apache License, Version 2.0 (the "License");
  you may not use this file except in compliance with the License.
  You may obtain a copy of the License at

      https://www.apache.org/licenses/LICENSE-2.0

  Unless required by applicable law or agreed to in writing, software
  distributed under the License is distributed on an "AS IS" BASIS,
  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  See the License for the specific language governing permissions and
  limitations under the License.

  Part of the D2CSharp project by t2t-soft. See LICENSE and NOTICE.
*/


public class RtlconstsInterface
{
	public static string SAncestorNotFound = 	"Ancestor not found: %s";
	public static string SAssignError = 	"Cannot assign %s to %s";
	public static string SBitsIndexError = 	"Bit index is outside the valid range";
	public static string SBucketListLocked = 	"The bucket list is locked";
	public static string SInvalidPropertyPath = 	"Invalid property path";
	public static string SInvalidPropertyType = 	"Invalid property type: %s";
	public static string SInvalidPropertyValue = 	"Invalid property value";
	public static string SInvalidRegType = 	"Invalid registry type: %s";
	public static string SInvalidString = 	"Invalid string";
	public static string SInvalidStringGridOp = 	"Invalid string grid operation";
	public static string SInvalidStringLength = 	"Invalid string length";
	public static string SItemNotFound = 	"Item not found";
	public static string SLineTooLong = 	"Line is too long";
	public static string SListCapacityError = 	"Invalid list capacity: %d";
	public static string SListCountError = 	"Invalid list count: %d";
	public static string SListIndexError = 	"List index out of bounds: %d";
	public static string SMaskErr = 	"Invalid mask value";
	public static string SMaskEditErr = 	"Invalid masked edit value";
	public static string SMemoryBufferOverrun = 	"Memory buffer overrun";
	public static string SParamIsNil = 	"Parameter %s must not be nil";
	public static string SParamIsNegative = 	"Parameter %s must not be negative";
	public static string SArgumentOutOfRange = 	"Argument is outside the valid range";
	public static string SArgumentOutOfRange_NeedNonNegValue = 	"Argument %s must not be negative";
	public static string SArgumentOutOfRange_OffLenInvalid = 	"Offset and length are outside the valid range";
	public static string SInputBufferExceed = 	"Input buffer limit exceeded";
	public static string SInvalidCharsInPath = 	"Path contains invalid characters";
	public static string SInvalidCharsInFileName = 	"File name contains invalid characters";
	public static string SInvalidCharsInSearchPattern = 	"Search pattern contains invalid characters";
	public static string SPathTooLong = 	"Path is too long";
	public static string SPathNotFound = 	"Path not found";
	public static string SPathFormatNotSupported = 	"Path format is not supported";
	public static string SDirectoryNotEmpty = 	"Directory is not empty";
	public static string SDirectoryAlreadyExists = 	"Directory already exists";
	public static string SDirectoryInvalid = 	"Directory name is invalid";
	public static string SSourceDirIsDestDir = 	"Source and destination directories are the same";
	public static string SSourceFileIsDestFile = 	"Source and destination files are the same";
	public static string SPathToFileNeeded = 	"A file path is required";
	public static string SSameRootDrive = 	"Source and destination must use the same root drive";
	public static string SInvalidStringAndObjectArrays = 	"String and object array sizes differ";
	public static string SSameArrays = 	"Source and destination arrays must differ";
	public static string SNoConstruct = 	"Object %s is not constructed";
	public static string SInvalidTimeoutValue = 	"Invalid timeout value: %s";
	public static string SNamedSyncObjectsNotSupported = 	"Named synchronization objects are not supported";
	public static string SParameterCountMismatch = 	"Parameter count mismatch";
	public static string SParameterCountExceeded = 	"Parameter count exceeded";
	public static string SConversionError = 	"Conversion error";
	public static string SNonPublicType = 	"Type %s is not public";
	public static string SByRefArgMismatch = 	"Reference argument types do not match";
	public static string SInsufficientReadBuffer = 	"Read buffer is too small";
	public static string SInvalid7BitEncodedInteger = 	"Invalid 7-bit encoded integer";
	public static string SNoSurrogates = 	"Surrogate code point is not valid here";
	public static string SReadPastEndOfStream = 	"Attempt to read past the end of the stream";
	public static string SInvalidGuidArray = 	"Invalid GUID byte array length";
	
} // class RtlconstsInterface


file class RtlconstsImplementation
{

} // class RtlconstsImplementation

}  // namespace Rtlconsts

}  // namespace System

