namespace BalanceFlow.Shared.Logging
{
    public static class LogMessages
    {
        public static string InvalidCashEntryInputs() => "Message: Invalid inputs to CashEntry.";
        public static string AddingCashEntryError(Exception ex) => $"Message: Error adding a new Cash Entry: {ex.Message}";
        public static string AddingCashEntrySuccess() => "Message: Successfully added a new Cash entry.";
        public static string GetAllCashEntryError(Exception ex) => $"Message: Error to loading the list Casy Entry: {ex.Message}";
        public static string GetAllCashEntrySuccess() => "Message: GetAll with success Casy Entry.";

        //public static string InvalidPessoalProfileInputs() => "Message: Invalid inputs to Pessoal Profile.";        
        //public static string AddingPessoalProfileError(Exception ex) => $"Message: Error adding a new Pessoal Profile: {ex.Message}";
        //public static string AddingPessoalProfileSuccess() => "Message: Successfully added a new Pessoal Profile.";        
        //public static string GetAllPessoalProfileError(Exception ex) => $"Message: Error to loading the list Pessoal Profile: {ex.Message}";
        //public static string GetAllPessoalProfileSuccess() => "Message: GetAll with success Pessoal Profile.";
    }
}