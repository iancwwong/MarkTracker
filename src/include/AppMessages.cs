using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTracker.include {
    /**
     * Contains a bunch of constant messages for dialogue boxes 
     */
    class DialogueMessages {

        /* Course related messages */
        public const string COURSE_REMOVE_CONFIRMATION = "Are you sure you want to remove the selected course?";

        /* Assessment related messages */
        public const string ASSESSMENT_REMOVE_CONFIRMATION = "Are you sure you want to remove the selected assessment?";

        /* Course related message */
        public const string COMPONENT_REMOVE_CONFIRMATION = "Are you sure you want to remove the selected component?";

        /* Group related messages */
        public const string GROUP_REMOVE_CONFIRMATION = "Are you sure you want to remve the selected group?";

    }

    /**
     * Messages for tooltips
     */
    class TooltipMessages {
        public const string ASSESSMENT_PANEL_INFO = "View and add courses or assessments here";
        public const string PARTICIPANT_PANEL_INFO = "View and add groups or students here";
    }
}
