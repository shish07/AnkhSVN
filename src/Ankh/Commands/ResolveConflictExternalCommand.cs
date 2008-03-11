// $Id: ResolveConflictCommand.cs 1580 2004-07-24 01:44:31Z Arild $
using System;
using Ankh.UI;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections;
using AnkhSvn.Ids;


namespace Ankh.Commands
{
    /// <summary>
    /// Command to resolve conflict between changes using external tool.
    /// </summary>
    [Command(AnkhCommand.ResolveConflictExternal)]
    public class ResolveConflictExternalCommand : ResolveConflictCommand
    {
        #region Implementation of ICommand

        public override void OnUpdate(CommandUpdateEventArgs e)
        {
            IContext context = e.Context.GetService<IContext>();

            if (!context.Config.ChooseDiffMergeManual || context.Config.MergeExePath == null)
            {
                e.Enabled = e.Visible = false;
            }
        }

        /// <summary>
        /// Gets path to the diff executable while taking care of config file settings.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>The exe path.</returns>
        protected override string GetExe( Ankh.IContext context )
        {
            return context.Config.MergeExePath;
        }

        #endregion
    }
}