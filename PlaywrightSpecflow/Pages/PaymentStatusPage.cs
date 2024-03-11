using Microsoft.Playwright;

namespace PlaywrightSpecflow.Pages;

public class PaymentStatusPage
{
    private  IPage _page;
    
    public PaymentStatusPage(IPage page) => _page = page;
    
    private ILocator approvalStage1 =>  _page.Locator("#Approval1");
    private ILocator approvalStage2 => _page.Locator("#Approval2");

    public async Task<bool> ApprovalStage1Complete() => await approvalStage1.IsVisibleAsync();
    public async Task<bool> ApprovalStage2Complete() => await approvalStage2.IsVisibleAsync();


   
    

}