using FluentAssertions;
using PlaywrightSpecflow.Drivers;
using PlaywrightSpecflow.Pages;
using TechTalk.SpecFlow.Assist;

namespace PlaywrightSpecflow.Steps;

[Binding]
public sealed class PaymentsTestSteps
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly Driver _driver;
    private readonly LoginPage _loginPage;
    private readonly PaymentInputPage _paymentInputPage;
    private readonly PaymentStatusPage _paymentStatusPage;


    public PaymentsTestSteps(Driver driver)
    {
        _driver = driver;
        _loginPage = new LoginPage(_driver.Page);
        _paymentInputPage = new PaymentInputPage(_driver.Page);
        _paymentStatusPage = new PaymentStatusPage(_driver.Page);
    }


    [Given(@"I navigate to the payment application")]
    public void GivenINavigateToThePaymentApplication()
    {
        _driver.Page.GotoAsync("www.bbc.co.uk");
    }

    [Given(@"I login with the following details")]
    public async Task GivenILoginWithTheFollowingDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _loginPage.Login((string)data.UserName,(string)data.Password );
       
    }

    [Then(@"I am able to select a payment method")]
    public async Task ThenIAmAbleToSelectAPaymentMethod()
    {
        var ukBankDisplayed = await _paymentInputPage.UkBankPaymentDisplayed();
        var intBankDisplayed = await _paymentInputPage.InternationalBankPaymentDisplayed();
        var creditCardPaymentDisplayed = await _paymentInputPage.CreditCardPaymentDisplayed();
        
        ukBankDisplayed.Should().Be(true);
        intBankDisplayed.Should().Be(true);
        creditCardPaymentDisplayed.Should().Be(true);


    }

    [Then(@"I am able to select UK Bank as payment method")]
    public async Task ThenIAmAbleToSelectUkBankAsPaymentMethod()
    {
        await _paymentInputPage.SelectUKBank();
    }

    [Then(@"I can enter the bank details")]
    public async Task ThenICanEnterTheBankDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _paymentInputPage.EnterUKBankDetails((string)data.firstname,(string)data.surname,(string)data.sortcode,(string)data.accountnumber);
    }

    [Then(@"submit the payment")]
    public async Task ThenSubmitThePayment()
    {
        await _paymentInputPage.SubmitPayment();
    }

    [Then(@"I can see the single approval status")]
    public async Task ThenICanSeeTheApprovalStatus()
    {
        var approval1Status = await _paymentStatusPage.ApprovalStage1Complete();
        approval1Status.Should().Be(true);
        
        
    }

    [Then(@"I am able to select International Bank as payment method")]
    public async Task ThenIAmAbleToSelectInternationalBankAsPaymentMethod()
    {
        await _paymentInputPage.SelectInternationalBank();
    }

    [Then(@"I can enter the international bank details")]
    public async Task ThenICanEnterTheInternationalBankDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _paymentInputPage.EnterInternationalBankDetails((string)data.firstname,(string)data.surname,(string)data.IBAN);
    }

    [Then(@"I can see the multiple approval status")]
    public async Task  ThenICanSeeTheMultipleApprovalStatus()
    {
        var approval1Status = await _paymentStatusPage.ApprovalStage1Complete();
        var approval2Status = await _paymentStatusPage.ApprovalStage2Complete();
        approval1Status.Should().Be(true);
        approval2Status.Should().Be(true);
    }
}