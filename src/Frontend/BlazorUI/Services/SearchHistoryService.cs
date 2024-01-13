using Blazored.LocalStorage;
using System.Buffers;

namespace TA_JeanEdwards.BlazorUI.Services
{
    public class SearchHistoryService
    {
        private readonly ILocalStorageService _localStorage;
        public List<string> searchHistory = [];

        public event Action OnChange;
        public SearchHistoryService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task LoadSearchHistoryAsync(bool updateState = true)
        {
            List<string> histories = await _localStorage.GetItemAsync<List<string>>("searchHistories");
            if (histories is not null)
            {
                searchHistory = histories;
            }

            if (updateState) NotifyStateChanged();
        }

        public async Task RemoveEntryAsync(string value)
        {
            searchHistory.RemoveAll(term => term.Equals(value, StringComparison.OrdinalIgnoreCase));
            await _localStorage.SetItemAsync("searchHistories", searchHistory);
            await LoadSearchHistoryAsync(true);
        }

        public async Task UpdateHistoryAsync(string searchValue)
        {
            await LoadSearchHistoryAsync(false);
            searchHistory.RemoveAll(term => term.Equals(searchValue, StringComparison.OrdinalIgnoreCase));

            searchHistory.Insert(0, searchValue);

            if (searchHistory.Count > 5)
            {
                searchHistory.RemoveAt(5);
            }

            await _localStorage.SetItemAsync("searchHistories", searchHistory);
            await LoadSearchHistoryAsync(true);
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
