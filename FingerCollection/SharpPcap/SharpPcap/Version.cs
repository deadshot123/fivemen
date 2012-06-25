/*
Copyright (c) 2005 Tamir Gal, http://www.tamirgal.com, All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

	1. Redistributions of source code must retain the above copyright notice,
		this list of conditions and the following disclaimer.

	2. Redistributions in binary form must reproduce the above copyright 
		notice, this list of conditions and the following disclaimer in 
		the documentation and/or other materials provided with the distribution.

	3. The names of the authors may not be used to endorse or promote products
		derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED WARRANTIES,
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR
OR ANY CONTRIBUTORS TO THIS SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;

namespace Tamir.IPLib
{
	/// <summary>
	/// Represent the current version of SharpPcap.
	/// </summary>
	/// <author>Tamir Gal</author>
	/// <version>  $Revision: 1.3 $ </version>
	/// <lastModifiedBy>  $Author: tamirgal $ </lastModifiedBy>
	/// <lastModifiedAt>  $Date: 2007/07/16 08:49:14 $ </lastModifiedAt>
	public class Version
	{
		/// <summary>
		/// Returns the current version string of the SharpPcap library
		/// </summary>
		/// <returns>the current version string of the SharpPcap library</returns>
		public static string GetVersionString()
		{
			System.Reflection.Assembly asm
				= System.Reflection.Assembly.GetAssembly(typeof(Tamir.IPLib.Version));
			return asm.GetName().Version.ToString();
		}
	}
}
