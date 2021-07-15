﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, TURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public BattleState state;

    public GameObject player;
    public GameObject enemy;
    public GameObject playerAttackPose;
    public GameObject playerFlinchPose;
    public GameObject playerDeathPose;

    public Transform playerStation;
    public Transform enemyStation;

    private Unit playerUnit;
    private Unit enemyUnit;

    public Text dialogue;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    void Start()
    {
        state = BattleState.START;

        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerObject = Instantiate(player, playerStation);
        playerUnit = playerObject.GetComponent<Unit>();

        GameObject enemyObject = Instantiate(enemy, enemyStation);
        enemyUnit = enemyObject.GetComponent<Unit>();

        dialogue.text = "An " + enemyUnit.name + " Approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(3);

        state = BattleState.TURN;
        playerTurn();

    }

    IEnumerator playerAttack()
    {
        bool isDead = enemyUnit.Damaged(playerUnit.damage);

        enemyHUD.setHealth(enemyUnit.currentHealth);
        dialogue.text = "You Attacked";

        yield return new WaitForSeconds(1);

        playerAttackPose.SetActive(false);

        yield return new WaitForSeconds(2);

        if (isDead == true)
        {
            state = BattleState.WON;
            endBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }

    }

    IEnumerator playerHeal()
    {
        playerUnit.heal(5);

        playerHUD.setHealth(playerUnit.currentHealth);

        dialogue.text = "You Healed!!!";

        yield return new WaitForSeconds(2);

        state = BattleState.ENEMYTURN;

        StartCoroutine(enemyTurn());
    }

    IEnumerator enemyTurn()
    {
        dialogue.text = "Enemy Turn!!!";

        yield return new WaitForSeconds(2);

        dialogue.text = enemyUnit.name + " Attacks!!!";

        playerFlinchPose.SetActive(true);

        bool isDead = playerUnit.Damaged(enemyUnit.damage);

        playerHUD.setHealth(playerUnit.currentHealth);

        yield return new WaitForSeconds(1);

        playerFlinchPose.SetActive(false);

        yield return new WaitForSeconds(2);

        if (isDead == true)
        {
            state = BattleState.LOST;
            endBattle();
        }
        else
        {
            state = BattleState.TURN;
            playerTurn();
        }
    }

    void playerTurn()
    {
        dialogue.text = "What will you do?";
    }

    public void attackButton()
    {
        if (state != BattleState.TURN)
        {
            return;
        }

        playerAttackPose.SetActive(true);

        StartCoroutine(playerAttack());
    }

    public void healButton()
    {
        if (state != BattleState.TURN)
        {
            return;
        }

        StartCoroutine(playerHeal());
    }

    void endBattle()
    {
        if(state == BattleState.WON)
        {
            playerDeathPose.SetActive(true);
            dialogue.text = "CONGRATULATIONS";
        }
        else if (state == BattleState.LOST)
        {
            playerDeathPose.SetActive(true);
            dialogue.text = "YOU LOST";
        }
    }
}
