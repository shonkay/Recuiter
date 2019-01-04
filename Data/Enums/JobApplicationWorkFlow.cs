﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
	public enum JobApplicationWorkFlow
	{
		Requested = 1,
		AwaitingHRReview,
		AwaitingHODReview,
		InterviewSchedule,
		InterviewRequest,
		InterviewProcess,
		Successfull,
		Archived,
		Rejected
	}

	public enum WorkFlowType
	{
		JobApplication = 1,
		Interview
	}
}
