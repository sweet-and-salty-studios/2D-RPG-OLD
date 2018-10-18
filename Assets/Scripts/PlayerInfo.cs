using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : Singelton<PlayerInfo>
{
	private const int MAX_VALUE = 100;

	private Transform HealthBar;
	private Transform ManaBar;
	private Transform ExpBar;

	private Image healthBarContent;
	private Image manaBarContent;
	private Image expBarContent;

	private Text healthValueText;
	private Text manaValueText;
	private Text expValueText;

	private void Awake()
	{
		HealthBar = transform.Find("HealthBar");
		ManaBar = transform.Find("ManaBar");
		ExpBar = transform.Find("ExpBar");

		healthBarContent = HealthBar.Find("Content").GetComponent<Image>();
		manaBarContent = ManaBar.Find("Content").GetComponent<Image>();
		expBarContent = ExpBar.Find("Content").GetComponent<Image>();

		healthValueText = healthBarContent.GetComponentInChildren<Text>();
		manaValueText = manaBarContent.GetComponentInChildren<Text>();
		expValueText = expBarContent.GetComponentInChildren<Text>();
	}

	private void Start()
	{
		healthValueText.text = (healthBarContent.fillAmount = MAX_VALUE).ToString();
		manaValueText.text = (manaBarContent.fillAmount = MAX_VALUE).ToString();
		expValueText.text = (expBarContent.fillAmount = 0f).ToString();

	   
	}
}
