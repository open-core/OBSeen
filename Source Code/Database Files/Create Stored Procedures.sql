DELIMITER //
CREATE procedure spInsertTimesheetEntriesForPerson (IN ClockIn DateTime)
BEGIN
	DECLARE p_ID INT DEFAULT 1;
    SET p_ID = (SELECT distinct PersonID FROM CurrentPerson limit 1);
	INSERT INTO TimesheetEntries (ClockIn,PersonID) VALUES(ClockIn,p_ID);
END //
DELIMITER ;

DELIMITER //
CREATE procedure spUpdateTimesheetEntriesForPerson (IN ID int, IN ClockIn DateTime, IN ClockOut Datetime, IN UnpaidTimeSpanTicks BIGINT, IN PaidTimeSpanTicks BIGINT, IN BreakStart datetime)
BEGIN
--    create temporary table temp_Table (T_id int, clock_in datetime, clock_out datetime, unpaidTicks bigint, paidTicks bigint);
--    insert into temp_Table
--    set T_id=ID,clock_in=ClockIn,clock_out=ClockOut,unpaidTicks=UnpaidTimeSpanTicks,paidTicks=PaidTimeSpanTicks;
    
	DECLARE p_ID INT DEFAULT 1;
    SET p_ID = (SELECT distinct PersonID FROM CurrentPerson limit 1);
    
	INSERT INTO TimesheetEntries(ID,ClockIn,ClockOut,UnpaidTime,PaidTime,PersonID,BreakStart)
    VALUES (ID,ClockIn,ClockOut,UnpaidTimeSpanTicks,PaidTimeSpanTicks,p_ID,BreakStart)
    ON DUPLICATE KEY UPDATE ClockIn = ClockIn, ClockOut = ClockOut, UnpaidTime = UnpaidTimeSpanTicks, PaidTime = PaidTimeSpanTicks, BreakStart = BreakStart;
    
--    SELECT row_count() INTO AffectedRows;
END //
DELIMITER ;

DELIMITER //
CREATE procedure spUpdateRosterEntriesforRoster (IN ID int, IN RosterID int, IN UserID int, IN EntryDate Date, IN StartTime Time, IN EndTime Time, IN UnpaidTimeTicks BIGINT, IN PaidTimeTicks BIGINT)
BEGIN
	INSERT INTO RosterEntries(ID,RosterID,UserID,EntryDate,StartTime,EndTime,UnpaidTimeTicks,PaidTimeTicks)
    VALUES (ID,RosterID,UserID,EntryDate,StartTime,EndTime,UnpaidTimeTicks,PaidTimeTicks)
    ON duplicate key update RosterID = RosterID, UserID = UserID, EntryDate = EntryDate, StartTime = StartTime, EndTime = EndTime, UnpaidTimeTicks = UnpaidTimeTicks, PaidTimeTicks = PaidTimeTicks;
END //
DELIMITER ;