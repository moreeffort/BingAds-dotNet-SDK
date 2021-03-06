﻿//=====================================================================================================================================================
// Bing Ads .NET SDK ver. 9.3
// 
// Copyright (c) Microsoft Corporation
// 
// All rights reserved. 
// 
// MS-PL License
// 
// This license governs use of the accompanying software. If you use the software, you accept this license. 
//  If you do not accept the license, do not use the software.
// 
// 1. Definitions
// 
// The terms reproduce, reproduction, derivative works, and distribution have the same meaning here as under U.S. copyright law. 
//  A contribution is the original software, or any additions or changes to the software. 
//  A contributor is any person that distributes its contribution under this license. 
//  Licensed patents  are a contributor's patent claims that read directly on its contribution.
// 
// 2. Grant of Rights
// 
// (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, 
//  each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, 
//  prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
// 
// (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, 
//  each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, 
//  sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
// 
// 3. Conditions and Limitations
// 
// (A) No Trademark License - This license does not grant you rights to use any contributors' name, logo, or trademarks.
// 
// (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, 
//  your patent license from such contributor to the software ends automatically.
// 
// (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, 
//  and attribution notices that are present in the software.
// 
// (D) If you distribute any portion of the software in source code form, 
//  you may do so only under this license by including a complete copy of this license with your distribution. 
//  If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
// 
// (E) The software is licensed *as-is.* You bear the risk of using it. The contributors give no express warranties, guarantees or conditions.
//  You may have additional consumer rights under your local laws which this license cannot change. 
//  To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, 
//  fitness for a particular purpose and non-infringement.
//=====================================================================================================================================================

using Microsoft.BingAds.Internal;
using Microsoft.BingAds.Internal.OAuth;

namespace Microsoft.BingAds
{
    /// <summary>
    /// Represents an OAuth authorization object implementing the authorization code grant flow for use in a desktop or mobile application. 
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can use an instance of this class as the <see cref="AuthorizationData.Authentication"/> property of an <see cref="AuthorizationData"/> object to authenticate with Bing Ads services.
    /// In this case the AuthenticationToken request header will be set to the corresponding <see cref="OAuthTokens.AccessToken"/> value.
    /// </para>
    /// <para>
    /// This class implements the authorization code grant flow for Managing User Authentication with OAuth 
    /// documented at http://go.microsoft.com/fwlink/?LinkID=511609. This is a standard OAuth 2.0 flow and is defined in detail in the 
    /// Authorization Code Grant section of the OAuth 2.0 spec at http://tools.ietf.org/html/draft-ietf-oauth-v2-15#section-4.1.
    /// For more information about registering a Bing Ads application, see http://go.microsoft.com/fwlink/?LinkID=511607. 
    /// </para>    
    /// </remarks>
    
    public class OAuthDesktopMobileAuthCodeGrant : OAuthWithAuthorizationCode
    {       
        /// <summary>
        /// Initializes a new instance of the OAuthDesktopMobileAuthCodeGrant class with the specified ClientId.
        /// </summary>
        /// <param name="clientId">
        /// The client identifier corresponding to your registered application.  
        /// </param>        
        /// <remarks>
        /// For more information about using a client identifier for authentication, see the 
        /// Client Password Authentication section of the OAuth 2.0 spec at http://tools.ietf.org/html/draft-ietf-oauth-v2-15#section-3.1
        /// </remarks>
        public OAuthDesktopMobileAuthCodeGrant(string clientId)
            : base(clientId, null, LiveComOAuthService.DesktopRedirectUri)
        {

        }

        /// <summary>
        /// Initializes a new instance of the OAuthDesktopMobileAuthCodeGrant class with the specified ClientId.
        /// </summary>
        /// <param name="clientId">
        /// The client identifier corresponding to your registered application.  
        /// </param>
        /// <param name="refreshToken">
        /// The refresh token that should be used to request an access token.
        /// </param>
        /// <remarks>
        /// For more information about using a client identifier for authentication, see the 
        /// Client Password Authentication section of the OAuth 2.0 spec at http://tools.ietf.org/html/draft-ietf-oauth-v2-15#section-3.1
        /// </remarks>
        public OAuthDesktopMobileAuthCodeGrant(string clientId, string refreshToken)
            : base(clientId, null, LiveComOAuthService.DesktopRedirectUri, refreshToken)
        {

        }

        internal OAuthDesktopMobileAuthCodeGrant(string clientId, IOAuthService oauthService)
            : base(clientId, null, LiveComOAuthService.DesktopRedirectUri, oauthService)
        {

        }
    }
}
