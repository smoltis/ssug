/*
SELECT
    t.task_state,
	t.session_id,
	ct.type,
    ct.forced_yield_count,
	w.is_preemptive,
	w.scheduler_address
	,ct.state
--	,ot.os_thread_id
FROM sys.dm_clr_tasks AS ct
JOIN sys.dm_os_tasks AS t ON
	t.task_address = ct.sos_task_address
JOIN sys.dm_os_workers AS w ON
	w.worker_address = t.worker_address
--JOIN sys.dm_os_threads AS ot ON
--	ot.worker_address = t.worker_address
*/
USE SQLCLR


-- DEMO 1a (Non cooperative thread)
EXEC SpinFor20Seconds_NoYield

-- DEMO 1b (cooperative thread)
EXEC [dbo].[SpinFor20Seconds_Yield]

-- DEMO 1c (Preemptive thread)
exec [dbo].[SpinFor20Seconds_Preemptive]

-- DEMO 2 (Allocations)
EXEC dbo.LargeAllocation
/*
Msg 6532, Level 16, State 49, Procedure LargeAllocation, Line 0 [Batch Start Line 2]
.NET Framework execution was aborted by escalation policy because of out of memory. 
*/
-- EXEC dbo.LargeAllocationConcurrent

-- DEMO 3 (orphaned monitor lock)
-- window1: 
-- select * from [dbo].[GetNumbers](1,1000000000)
-- window2: run and then abort
exec [dbo].[EnterMonitorAndSleep]

