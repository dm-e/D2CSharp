{
  D2CSharp Runtime Library (RTL)

  This Delphi source file provides a declaration-oriented mock of
  System.Internal.ExcUtils required by D2CSharp.

  System.Internal.ExcUtils is an internal RTL support unit used by
  System.SysUtils and the Delphi exception runtime. It is not modeled here
  as a public application-level API. The unit currently exists so that
  D2CSharp can resolve RTL dependencies without relying on proprietary
  Delphi RTL source code.

  Additional declarations should only be added when translated source or
  another MockRTL unit requires a specific symbol and its public signature
  can be established independently.

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

unit System.Internal.ExcUtils;

interface

implementation

end.
