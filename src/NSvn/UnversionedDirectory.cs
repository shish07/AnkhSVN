// $Id$
using System;

namespace NSvn
{
    /// <summary>
    /// Represents an unversioned directory in a working copy.
    /// </summary>
    [Obsolete("Will be removed in a future version")]
    public class UnversionedDirectory : UnversionedResource
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">File system path to the item.</param>
        public UnversionedDirectory( string path ) : base( path )
        {
            //empty
        }

        /// <summary>
        /// Is this a directory?
        /// </summary>
        public override bool IsDirectory
        {
            [System.Diagnostics.DebuggerStepThrough]
            get{ return true; }
        }

        /// <summary>
        /// Accepts an ILocalResourceVisitor.
        /// </summary>
        public override void Accept( ILocalResourceVisitor visitor )
        {
            visitor.VisitUnversionedDirectory( this );
        }
    }
}
