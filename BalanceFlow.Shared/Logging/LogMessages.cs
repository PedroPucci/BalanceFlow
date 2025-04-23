namespace BalanceFlow.Shared.Logging
{
    public static class LogMessages
    {
        public static string InvalidCashEntryInputs() => "Message: Invalid inputs to Cash Entry.";
        public static string AddingCashEntryError(Exception ex) => $"Message: Error adding a new Cash Entry: {ex.Message}";
        public static string AddingCashEntrySuccess() => "Message: Successfully added a new Cash entry.";
        public static string GetAllCashEntryError(Exception ex) => $"Message: Error to loading the list Casy Entry: {ex.Message}";
        public static string GetAllCashEntrySuccess() => "Message: GetAll with success Casy Entry.";


        public static string InvalidDailyBalanceInputs() => "Message: Invalid inputs to daily balance.";
        public static string AddingDailyBalanceError(Exception ex) => $"Message: Error adding a new daily balance: {ex.Message}";
        public static string AddingDailyBalanceSuccess() => "Message: Successfully added a new  daily balance.";
        public static string GetAllDailyBalanceSuccess() => "Message: GetAll with success daily balance.";
        public static string GetAllDailyBalanceError(Exception ex) => $"Message: Error to loading the list daily balance: {ex.Message}";
    }
}