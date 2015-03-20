﻿// This file is part of libnoise-dotnet.
//
// libnoise-dotnet is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// libnoise-dotnet is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with libnoise-dotnet.  If not, see <http://www.gnu.org/licenses/>.

using System;
using UNoise.Graphics.Tools.Noise.Utils;

namespace UNoise.Graphics.Tools.Noise.Builder {

	/// <summary>
	/// Implements a noise map, a 2-dimensional array of floating-point values.
	///
	/// A noise map is designed to store coherent-noise values generated by a
	/// noise module, although it can store values from any source.  A noise
	/// map is often used as a terrain height map or a grayscale texture.
	/// 
	/// </summary>
	public class NoiseMap :DataMap<float>, IMap2D<float> {

		#region Ctor/Dtor

		/// <summary>
		/// Create an empty NoiseMap
		/// </summary>
		public NoiseMap() {
			_hasMaxDimension = false;

			_borderValue = 0.0f;
			AllocateBuffer();
		}//End NoiseMap

		/// <summary>
		/// Create a new NoiseMap with the given values
		///
		/// The width and height values are positive.
		/// The width and height values do not exceed the maximum
		/// possible width and height for the noise map.
		///
		/// @throw System.ArgumentException See the preconditions.
		/// @throw noise::ExceptionOutOfMemory Out of memory.
		///
		/// Creates a noise map with uninitialized values.
		///
		/// It is considered an error if the specified dimensions are not
		/// positive.
		/// </summary>
		/// <param name="width">The width of the new noise map.</param>
		/// <param name="height">The height of the new noise map</param>
		public NoiseMap(int width, int height) {
			_hasMaxDimension = false;
			_borderValue = 0.0f;
			AllocateBuffer(width, height);
			
		}//End NoiseMap

		/// <summary>
		/// Copy constructor
		/// @throw noise::ExceptionOutOfMemory Out of memory.
		/// </summary>
		/// <param name="copy">The NoiseMap to copy</param>
		public NoiseMap(NoiseMap copy) {
			_hasMaxDimension = false;
			_borderValue = 0.0f;
			CopyFrom(copy);
		}//End NoiseMap

		#endregion

		#region Interaction

		/// <summary>
		/// Find the lowest and highest value in the map
		/// </summary>
		/// Cannot implement this method in DataMap because 
		/// T < T or T > T does not compile (Unpredictable type of T)
		/// <param name="min">the lowest value</param>
		/// <param name="max">the highest value</param>
		public void MinMax(out float min, out float max) {

			min = max = 0f;

			if(_data != null && _data.Length > 0) {

				// First value, min and max for now
				min = max = _data[0];

				for(int i = 1; i < _data.Length; i++) {

					if(min > _data[i]) {
						min = _data[i];
					}//end if
					else if(max < _data[i]) {
						max = _data[i];
					}//end else if

				}//end for

			}//end if

		}//end MinMax

		#endregion

		#region Internal

		/// <summary>
		/// Return the memory size of a float
		/// </summary>
		/// <returns>The memory size of a float</returns>
		protected override int SizeofT() {
			return 32;
		}//end protected

		/// <summary>
		/// Return the maximum value of a float type
		/// </summary>
		/// <returns></returns>
		protected override float MaxvalofT() {
			return float.MaxValue;
		}//end protected

		/// <summary>
		/// Return the minimum value of a float type
		/// </summary>
		/// <returns></returns>
		protected override float MinvalofT() {
			return float.MinValue;
		}//end protected

		#endregion
	}//end class

}//end namespace
