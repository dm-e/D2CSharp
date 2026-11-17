{
  D2CSharp Runtime Library (RTL)

  Independent declaration-oriented Delphi mock source.
  The corresponding C# files are automatically translated from the
  Delphi source files by D2CSharp.
  This notice is retained unchanged in both versions.

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

{ Declaration-only mock; runtime behavior is implemented in the C# RTL. }
unit System.HelpIntfs;
interface
uses System.SysUtils, System.Classes;
type
  IHelpSelector = interface(IInterface)
    ['{B0FC9358-5F0E-11D3-A3B9-00C04F79AD3A}']
    function SelectKeyword(Keywords: TStrings) : Integer;
    function TableOfContents(Contents: TStrings): Integer;
  end;
  IHelpSelector2 = interface(IHelpSelector)
    ['{F65368F4-CA3B-482C-ABD2-3FC23F801D8B}']
    function SelectContext(Viewers: TStrings): Integer;
  end;
  IHelpSystem = interface(IInterface)
    ['{B0FC9353-5F0E-11D3-A3B9-00C04F79AD3A}']
    procedure ShowHelp(const HelpKeyword, HelpFileName: string);
    procedure ShowContextHelp(const ContextID: THelpContext; const HelpFileName: string);
    procedure ShowTableOfContents;
    procedure ShowTopicHelp(const Topic, HelpFileName: string);
    procedure AssignHelpSelector(const Selector: IHelpSelector);
    function Hook(Handle: THandle; const HelpFile: string; Comand: Word; Data: NativeInt): Boolean;
  end;
  IHelpSystem2 = interface(IHelpSystem)
    ['{48C5336E-71E2-4406-A08E-F915FBA5C9D4}']
    function UnderstandsKeyword(const HelpKeyword, HelpFileName: string): Boolean;
  end;
  IHelpSystem3 = interface(IHelpSystem2)
    ['{006A65EE-9A5E-4EB1-828F-A7F1D79DD202}']
    procedure ShowIndex(const Topic, HelpFileName: string);
    procedure ShowSearch(const Topic, HelpFileName: string);
    procedure ShowTopicHelp(const Topic, Anchor, HelpFileName: string); overload;
    function GetFilter: string;
    procedure SetFilter(const Filter: string);
  end;
  ICustomHelpViewer = interface(IInterface)
    ['{B0FC9364-5F0E-11D3-A3B9-00C04F79AD3A}']
    function  GetViewerName: string;
    function  UnderstandsKeyword(const HelpString: string): Integer;
    function  GetHelpStrings(const HelpString: string): TStringList;
    function  CanShowTableOfContents : Boolean;
    procedure ShowTableOfContents;
    procedure ShowHelp(const HelpString: string);
    procedure NotifyID(const ViewerID: Integer);
    procedure SoftShutDown;
    procedure ShutDown;
  end;
  IExtendedHelpViewer = interface(ICustomHelpViewer)
    ['{B0FC9366-5F0E-11D3-A3B9-00C04F79AD3A}']
    function UnderstandsTopic(const Topic: string): Boolean;
    procedure DisplayTopic(const Topic: string);
    function UnderstandsContext(const ContextID: THelpContext;
      const HelpFileName: string): Boolean;
    procedure DisplayHelpByContext(const ContextID: THelpContext;
      const HelpFileName: string);
  end;
  IExtendedHelpViewer2 = interface(IExtendedHelpViewer)
    ['{DD46A379-569A-46AA-89E5-8AACA764304B}']
    procedure DisplayIndex(const Topic: string);
    procedure DisplaySearch(const Topic: string);
    procedure DisplayTopic(const Topic, Anchor: string); overload;
  end;
  IFilteredHelpViewer = interface(IExtendedHelpViewer2)
    ['{991F8E1A-2E3F-4ACB-91A8-4B9587BBA878}']
    function GetFilter: string;
    procedure SetFilter(const Filter: string);
  end;
  ISpecialWinHelpViewer = interface(IExtendedHelpViewer)
    ['{1A7B2224-1EAE-4313-BAD6-3C32F8F77085}']
    function CallWinHelp(Handle: THandle; const HelpFile: string; Command: Word;
      Data: NativeUInt): Boolean;
  end;
  IHelpSystemFlags = interface(IExtendedHelpViewer)
    ['{69418F09-5E49-4899-9E13-9FE3C1497566}']
    function GetUseDefaultTopic: Boolean;
    procedure SetUseDefaultTopic(AValue: Boolean);
  end;
  IHelpManager = interface
    ['{6B0CDB05-C30A-414B-99C4-F11CD195385E}']
    function  GetHandle: THandle; 
    function GetHelpFile: string;
    procedure Release(const ViewerID: Integer);
  end;
  EHelpSystemException = class(Exception);
  function RegisterViewer(const newViewer: ICustomHelpViewer;
    out Manager: IHelpManager): Integer;
  function GetHelpSystem(out System: IHelpSystem): Boolean; overload;
  function GetHelpSystem(out System: IHelpSystem2): Boolean; overload;
  function GetHelpSystem(out System: IHelpSystem3): Boolean; overload;

implementation
function RegisterViewer(const newViewer: ICustomHelpViewer; out Manager: IHelpManager): Integer;
begin Manager := nil; Result := 0 end;
function GetHelpSystem(out System: IHelpSystem): Boolean;
begin System := nil; Result := False end;
function GetHelpSystem(out System: IHelpSystem2): Boolean;
begin System := nil; Result := False end;
function GetHelpSystem(out System: IHelpSystem3): Boolean;
begin System := nil; Result := False end;
end.
