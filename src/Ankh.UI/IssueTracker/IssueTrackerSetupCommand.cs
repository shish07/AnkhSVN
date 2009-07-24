﻿using Ankh.Commands;
using Ankh.Interop.IssueTracker;
using WizardFramework;

namespace Ankh.UI.IssueTracker
{
    [Command(Ankh.Ids.AnkhCommand.SolutionIssueTrackerSetup)]
    class IssueTrackerSetupCommand : ICommandHandler
    {
        #region ICommandHandler Members

        public void OnUpdate(CommandUpdateEventArgs e)
        {
            IAnkhIssueService service = e.GetService<IAnkhIssueService>(typeof(IAnkhIssueService));
            e.Enabled = true
                && service != null
                && service.Connectors != null
                && service.Connectors.Count > 0;
        }

        public void OnExecute(CommandEventArgs e)
        {
            IAnkhIssueService service = e.GetService<IAnkhIssueService>(typeof(IAnkhIssueService));
            IIssueRepository repository = service.CurrentIssueRepository;
            // TODO pass the current settings (repository) to the dialog so that this command serves for "edit" purpose.
            using (WizardDialog dialog = new WizardDialog(new IssueTrackerConfigWizard(e.Context)))
            {
                dialog.ShowDialog(e.Context);
            }
        }

        #endregion
    }
}
