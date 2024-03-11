using Microsoft.Playwright;

namespace PlaywrightSpecflow.Pages;

public class LoginPage
{
    private  IPage _page;



    public LoginPage(IPage page) => _page = page;
    
    private ILocator _loginBtn => _page.Locator("text=Submit");
    private ILocator _userNameInput => _page.Locator("#Username");
    private ILocator _passwordInput => _page.Locator("#Password");
 

    

    public async Task Login(string userName, string password)
    {
        await _userNameInput.FillAsync(userName);
        await _passwordInput.FillAsync(password);
        await _loginBtn.ClickAsync();
    }
    
}