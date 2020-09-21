/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable IDE0005 // Using directive is unnecessary; are required depending on code-gen options
#pragma warning disable CA2227, CA1819 // Collection/Array properties should be read only; ignored, as acceptable for a DTO.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Beef.RefData;
using Newtonsoft.Json;
using RefDataNamespace = Beef.Demo.Common.Entities;

namespace Beef.Demo.Common.Entities
{
    /// <summary>
    /// Represents the Mapping arguments entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class MapArgs : EntityBase, IEquatable<MapArgs>
    {
        #region Privates

        private MapCoordinates? _coordinates;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Coordinates (see <see cref="Common.Entities.MapCoordinates"/>).
        /// </summary>
        [JsonProperty("coordinates", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [Display(Name="Coordinates")]
        [Beef.WebApi.WebApiArgFormatter(typeof(MapCoordinatesToStringConverter))]
        public MapCoordinates? Coordinates
        {
            get => _coordinates;
            set => SetValue(ref _coordinates, value, false, true, nameof(Coordinates));
        }

        #endregion

        #region IChangeTracking

        /// <summary>
        /// Resets the entity state to unchanged by accepting the changes (resets <see cref="EntityBase.ChangeTracking"/>).
        /// </summary>
        /// <remarks>Ends and commits the entity changes (see <see cref="EntityBase.EndEdit"/>).</remarks>
        public override void AcceptChanges()
        {
            Coordinates?.AcceptChanges();
            base.AcceptChanges();
        }

        /// <summary>
        /// Determines that until <see cref="AcceptChanges"/> is invoked property changes are to be logged (see <see cref="EntityBase.ChangeTracking"/>).
        /// </summary>
        public override void TrackChanges()
        {
            Coordinates?.TrackChanges();
            base.TrackChanges();
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing the values of all the properties.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is MapArgs val && Equals(val);

        /// <summary>
        /// Determines whether the specified <see cref="MapArgs"/> is equal to the current <see cref="MapArgs"/> by comparing the values of all the properties.
        /// </summary>
        /// <param name="value">The <see cref="MapArgs"/> to compare with the current <see cref="MapArgs"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="MapArgs"/> is equal to the current <see cref="MapArgs"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(MapArgs? value)
        {
            if (value == null)
                return false;
            else if (ReferenceEquals(value, this))
                return true;

            return base.Equals((object)value)
                && Equals(Coordinates, value.Coordinates);
        }

        /// <summary>
        /// Compares two <see cref="MapArgs"/> types for equality.
        /// </summary>
        /// <param name="a"><see cref="MapArgs"/> A.</param>
        /// <param name="b"><see cref="MapArgs"/> B.</param>
        /// <returns><c>true</c> indicates equal; otherwise, <c>false</c> for not equal.</returns>
        public static bool operator == (MapArgs? a, MapArgs? b) => Equals(a, b);

        /// <summary>
        /// Compares two <see cref="MapArgs"/> types for non-equality.
        /// </summary>
        /// <param name="a"><see cref="MapArgs"/> A.</param>
        /// <param name="b"><see cref="MapArgs"/> B.</param>
        /// <returns><c>true</c> indicates not equal; otherwise, <c>false</c> for equal.</returns>
        public static bool operator != (MapArgs? a, MapArgs? b) => !Equals(a, b);

        /// <summary>
        /// Returns the hash code for the <see cref="MapArgs"/>.
        /// </summary>
        /// <returns>The hash code for the <see cref="MapArgs"/>.</returns>
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Coordinates);
            return base.GetHashCode() ^ hash.ToHashCode();
        }
    
        #endregion

        #region ICopyFrom
    
        /// <summary>
        /// Performs a copy from another <see cref="MapArgs"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="MapArgs"/> to copy from.</param>
        public override void CopyFrom(object from)
        {
            var fval = ValidateCopyFromType<MapArgs>(from);
            CopyFrom(fval);
        }
        
        /// <summary>
        /// Performs a copy from another <see cref="MapArgs"/> updating this instance.
        /// </summary>
        /// <param name="from">The <see cref="MapArgs"/> to copy from.</param>
        public void CopyFrom(MapArgs from)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            CopyFrom((EntityBase)from);
            Coordinates = CopyOrClone(from.Coordinates, Coordinates);

            OnAfterCopyFrom(from);
        }

        #endregion

        #region ICloneable
        
        /// <summary>
        /// Creates a deep copy of the <see cref="MapArgs"/>.
        /// </summary>
        /// <returns>A deep copy of the <see cref="MapArgs"/>.</returns>
        public override object Clone()
        {
            var clone = new MapArgs();
            clone.CopyFrom(this);
            return clone;
        }
        
        #endregion
        
        #region ICleanUp

        /// <summary>
        /// Performs a clean-up of the <see cref="MapArgs"/> resetting property values as appropriate to ensure a basic level of data consistency.
        /// </summary>
        public override void CleanUp()
        {
            base.CleanUp();
            Coordinates = Cleaner.Clean(Coordinates);

            OnAfterCleanUp();
        }

        /// <summary>
        /// Indicates whether considered initial; i.e. all properties have their initial value.
        /// </summary>
        /// <returns><c>true</c> indicates is initial; otherwise, <c>false</c>.</returns>
        public override bool IsInitial
        {
            get
            {
                return Cleaner.IsInitial(Coordinates);
            }
        }

        #endregion

        #region PartialMethods
      
        partial void OnAfterCleanUp();

        partial void OnAfterCopyFrom(MapArgs from);

        #endregion
    }
}

#pragma warning restore CA2227, CA1819
#pragma warning restore IDE0005
#nullable restore