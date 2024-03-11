using Microsoft.Playwright;

namespace PlaywrightSpecflow.Pages;

public class PaymentInputPage
{
    private  IPage _page;

    
    
    public PaymentInputPage(IPage page) => _page = page;
    
    private ILocator ukBankSelector =>  _page.Locator("#UKBank");
    private ILocator internationalBankSelector => _page.Locator("#IntBank");
    private ILocator creditCardSelector => _page.Locator("#CreditCard"); 
    private ILocator firstNameInput => _page.Locator("#firstName");
    private ILocator surnameInput => _page.Locator("#surname");
    private ILocator sortCodeInput => _page.Locator("#sortcode");
    private ILocator accountNumberInput => _page.Locator("#accnumber");
    
    private ILocator submitBtn => _page.Locator("text=Submit");
    
    private ILocator ibanInput => _page.Locator("#iban");

    public async Task<bool> UkBankPaymentDisplayed() => await ukBankSelector.IsVisibleAsync();
    public async Task<bool> InternationalBankPaymentDisplayed() => await internationalBankSelector.IsVisibleAsync();
    public async Task<bool> CreditCardPaymentDisplayed() => await creditCardSelector.IsVisibleAsync();


    public async Task SelectUKBank()
    {
        await ukBankSelector.ClickAsync();
    }
    public async Task EnterUKBankDetails(string firstname, string surname, string sortcode, string accnumber)
    {
        await firstNameInput.FillAsync(firstname);
        await surnameInput.FillAsync(surname);
        await sortCodeInput.FillAsync(sortcode);
        await accountNumberInput.FillAsync(accnumber);

    }
    
    public async Task SelectInternationalBank()
    {
        await internationalBankSelector.ClickAsync();
    }
    public async Task EnterInternationalBankDetails(string firstname, string surname, string iban)
    {
        await firstNameInput.FillAsync(firstname);
        await surnameInput.FillAsync(surname);
        await ibanInput.FillAsync(iban);
       

    }
    
    public async Task SubmitPayment()
    {
        await submitBtn.ClickAsync();
    }
    

}