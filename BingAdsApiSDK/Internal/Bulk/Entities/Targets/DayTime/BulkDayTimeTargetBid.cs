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

using Microsoft.BingAds.Bulk.Entities;
using Microsoft.BingAds.CampaignManagement;
using Microsoft.BingAds.Internal.Bulk.Mappings;

// ReSharper disable once CheckNamespace
namespace Microsoft.BingAds.Internal.Bulk.Entities
{
    /// <summary>
    /// This abstract base class provides properties that are shared by all bulk day and time target bid classes.
    /// </summary>
    public abstract class BulkDayTimeTargetBid : BulkTargetBid
    {
        /// <summary>
        /// Defines a specific day of the week and time range to target.
        /// </summary>
        public DayTimeTargetBid DayTimeTargetBid { get; set; }

        /// <summary>
        /// Reserved for internal use. 
        /// </summary>
        protected BulkDayTimeTargetBid(BulkTargetIdentifier identifier)
            : base(identifier)
        {
            
        }

        private static readonly IBulkMapping<BulkDayTimeTargetBid>[] Mappings =
        {
            new SimpleBulkMapping<BulkDayTimeTargetBid>(StringTable.Target,
                c => c.DayTimeTargetBid.Day.ToBulkString(),
                (v, c) => c.DayTimeTargetBid.Day = v.Parse<Day>()
            ),

            new SimpleBulkMapping<BulkDayTimeTargetBid>(StringTable.FromHour,
                c => c.DayTimeTargetBid.FromHour.ToBulkString(),
                (v, c) => c.DayTimeTargetBid.FromHour = v.Parse<int>()
            ),

            new SimpleBulkMapping<BulkDayTimeTargetBid>(StringTable.ToHour,
                c => c.DayTimeTargetBid.ToHour.ToBulkString(),
                (v, c) => c.DayTimeTargetBid.ToHour = v.Parse<int>()
            ),

            new SimpleBulkMapping<BulkDayTimeTargetBid>(StringTable.FromMinute,
                c => c.DayTimeTargetBid.FromMinute.ToMinuteBulkString(),
                (v, c) => c.DayTimeTargetBid.FromMinute = v.ParseMinute()
            ),

            new SimpleBulkMapping<BulkDayTimeTargetBid>(StringTable.ToMinute,
                c => c.DayTimeTargetBid.ToMinute.ToMinuteBulkString(),
                (v, c) => c.DayTimeTargetBid.ToMinute = v.ParseMinute()
            ),

            new SimpleBulkMapping<BulkDayTimeTargetBid>(StringTable.BidAdjustment,
                c => c.DayTimeTargetBid.BidAdjustment.ToBulkString(),
                (v, c) => c.DayTimeTargetBid.BidAdjustment = v.Parse<int>()
            ),
        };

        internal override void ProcessMappingsFromRowValues(RowValues values)
        {
            DayTimeTargetBid = new DayTimeTargetBid();

            base.ProcessMappingsFromRowValues(values);

            values.ConvertToEntity(this, Mappings);
        }

        internal override void ProcessMappingsToRowValues(RowValues values, bool excludeReadonlyData)
        {
            ValidatePropertyNotNull(DayTimeTargetBid, "DayTimeTargetBid");

            base.ProcessMappingsToRowValues(values, excludeReadonlyData);

            this.ConvertToValues(values, Mappings);
        }
    }
}
