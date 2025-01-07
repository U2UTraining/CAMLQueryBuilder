using System;

namespace U2U.SharePoint.CAML.Enumerations
{
	/// <summary>
	/// Summary description for Enumerations.
	/// </summary>

    public enum ViewFieldActions
    {
        Add,
        AddAll,
        Remove,
        RemoveAll
    }

	public enum CamlTypes
	{
		Query,
		GetListItems,
        GetListItemChanges,
        GetListItemChangesSinceToken,
        UpdateListItems
	}

	public enum DataTypes
	{
        Attachments,
        Boolean,
        Choice,
        Computed,
        Counter,
        DateTime,
        Lookup,
        ModStat,
        MultiChoice,
        Number,
        Text,
		User,
		Note
	}

    public enum CalendarFields
    {
        EventDate,
        EndDate,
        RecurrenceID
    }

    public enum OccurrenceTypes
    {
        Today,
        Week,
        Month,
        Year
    }

	public enum ListImages
	{
		ITANN = 1,
		ITCONTCT = 2,
		ITDATASH = 3,
		ITDISC = 4,
		ITDL = 5,
		ITEVENT = 6,
		ITGEN = 7,
		ITIL = 8,
		ITISSUE = 9,
		ITLINK = 10,
		ITSURVEY = 11,
		ITTASK = 12,
		LISTGIF = 13,
		WEBGIF = 14
	}

}
