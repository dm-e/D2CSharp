{
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
}

unit System.RTLConsts;

interface

resourcestring
  SAncestorNotFound = 'Ancestor not found: %s';
  SAssignError = 'Cannot assign %s to %s';
  SBitsIndexError = 'Bit index is outside the valid range';
  SBucketListLocked = 'The bucket list is locked';
  SInvalidPropertyPath = 'Invalid property path';
  SInvalidPropertyType = 'Invalid property type: %s';
  SInvalidPropertyValue = 'Invalid property value';
  SInvalidRegType = 'Invalid registry type: %s';
  SInvalidString = 'Invalid string';
  SInvalidStringGridOp = 'Invalid string grid operation';
  SInvalidStringLength = 'Invalid string length';
  SItemNotFound = 'Item not found';
  SLineTooLong = 'Line is too long';
  SListCapacityError = 'Invalid list capacity: %d';
  SListCountError = 'Invalid list count: %d';
  SListIndexError = 'List index out of bounds: %d';
  SMaskErr = 'Invalid mask value';
  SMaskEditErr = 'Invalid masked edit value';
  SMemoryBufferOverrun = 'Memory buffer overrun';
  SParamIsNil = 'Parameter %s must not be nil';
  SParamIsNegative = 'Parameter %s must not be negative';
  SArgumentOutOfRange = 'Argument is outside the valid range';
  SArgumentOutOfRange_NeedNonNegValue = 'Argument %s must not be negative';
  SArgumentOutOfRange_OffLenInvalid = 'Offset and length are outside the valid range';
  SInputBufferExceed = 'Input buffer limit exceeded';
  SInvalidCharsInPath = 'Path contains invalid characters';
  SInvalidCharsInFileName = 'File name contains invalid characters';
  SInvalidCharsInSearchPattern = 'Search pattern contains invalid characters';
  SPathTooLong = 'Path is too long';
  SPathNotFound = 'Path not found';
  SPathFormatNotSupported = 'Path format is not supported';
  SDirectoryNotEmpty = 'Directory is not empty';
  SDirectoryAlreadyExists = 'Directory already exists';
  SDirectoryInvalid = 'Directory name is invalid';
  SSourceDirIsDestDir = 'Source and destination directories are the same';
  SSourceFileIsDestFile = 'Source and destination files are the same';
  SPathToFileNeeded = 'A file path is required';
  SSameRootDrive = 'Source and destination must use the same root drive';
  SInvalidStringAndObjectArrays = 'String and object array sizes differ';
  SSameArrays = 'Source and destination arrays must differ';
  SNoConstruct = 'Object %s is not constructed';
  SInvalidTimeoutValue = 'Invalid timeout value: %s';
  SNamedSyncObjectsNotSupported = 'Named synchronization objects are not supported';
  SParameterCountMismatch = 'Parameter count mismatch';
  SParameterCountExceeded = 'Parameter count exceeded';
  SConversionError = 'Conversion error';
  SNonPublicType = 'Type %s is not public';
  SByRefArgMismatch = 'Reference argument types do not match';
  SInsufficientReadBuffer = 'Read buffer is too small';
  SInvalid7BitEncodedInteger = 'Invalid 7-bit encoded integer';
  SNoSurrogates = 'Surrogate code point is not valid here';
  SReadPastEndOfStream = 'Attempt to read past the end of the stream';
  SInvalidGuidArray = 'Invalid GUID byte array length';

implementation

end.
