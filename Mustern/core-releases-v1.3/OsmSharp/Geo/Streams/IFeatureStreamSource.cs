﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2015 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

using OsmSharp.Geo.Features;
using OsmSharp.Math.Geo;
using System.Collections.Generic;

namespace OsmSharp.Geo.Geometries.Streams
{
    /// <summary>
    /// Represents a streamed source of features.
    /// </summary>
    public interface IFeatureStreamSource : IEnumerator<Feature>, IEnumerable<Feature>
    {
        /// <summary>
        /// Intializes this source.
        /// </summary>
        /// <rremarks>Has to be called before starting read objects.</rremarks>
        void Initialize();

        /// <summary>
        /// Returns true if this source can be reset.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Some sources cannot be reset, live feeds of objects for example.</remarks>
        bool CanReset();

        /// <summary>
        /// Closes this target.
        /// </summary>
        /// <remarks>Closes any open connections, file locks or anything related to this source.</remarks>
        void Close();

        /// <summary>
        /// Returns true if this source is bounded.
        /// </summary>
        bool HasBounds
        {
            get;
        }

        /// <summary>
        /// Returns the bounds of this source.
        /// </summary>
        /// <returns></returns>
        GeoCoordinateBox GetBounds();
    }
}