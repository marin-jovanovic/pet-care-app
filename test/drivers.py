from selenium.webdriver.common.by import By
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager

import time


def init():

    driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()))
    driver.get("https://localhost:7213/")


    try:
        click(driver, get_selectors()["ssl"]["details"])
        click(driver, get_selectors()["ssl"]["proceed"])

    except:
        pass

    time.sleep(3)

    return driver

def get_selectors():
    return {
        "ssl": {
            "details": "#details-button",
            "proceed": "#proceed-link"
        },

        "home": {
            "user": "body > div > div > div.center__container > div > div.navbar > div:nth-child(3) > div > button",
            "login": "body > div > div > div.center__container > div > div.navbar > div:nth-child(3) > div > div > a:nth-child(1)",
            "signup": "body > div > div > div.center__container > div > div.navbar > div:nth-child(3) > div > div > a:nth-child(2)"
        },

        "login": {
            "username": "#input__username",
            "password": "#input__password",
            "confirm": "#loginForm > table > tbody > tr:nth-child(3) > td > input"
        },

        "listings": {
            "my_listings": "body > div > div > div > div.navbar > div:nth-child(3) > input[type=button]:nth-child(1)",
            "logout": "body > div > div > div > div.navbar > div:nth-child(3) > input[type=button]:nth-child(2)"
        },

        "my_listings": {

        },

        "signup": {
            "username": "#input__username",
            "oib": "#input__OIB",
            "firstname": "#input__firstname",
            "lastname": "#input__lastname",
            "email": "#input__email",
            "card number": "#input__cardnumber",
            "card type": "#input__cardtype",
            "card month": "#input__card__month",
            "card year": "#input__card__year",
            "password": "#input__password",
            "password repeat": "#input__password_repeat",
            "confirm": "#registerFormU > div > span:nth-child(45) > input"
        },

        "logout": {
            "logout content": "body > div:nth-child(1) > div:nth-child(1)"
        }

    }

def click(driver, css_selector):
    print("selector", css_selector)
    time.sleep(1)
    elem = driver.find_element(by=By.CSS_SELECTOR, value=css_selector)
    elem.click()

def type(driver, css_selector, content):
    print("selector", css_selector)
    time.sleep(1)
    elem = driver.find_element(by=By.CSS_SELECTOR, value=css_selector)
    elem.send_keys(content)

def home(driver, login_or_signup):
    click(driver, get_selectors()["home"]["user"])

    if login_or_signup:
        click(driver, get_selectors()["home"]["login"])

    else:
        click(driver, get_selectors()["home"]["signup"])

def login(driver, username, password):
    type(driver, get_selectors()["login"]["username"], username)
    type(driver, get_selectors()["login"]["password"], password)
    click(driver, get_selectors()["login"]["confirm"])

def listings(driver, my_listings_or_logout):

    if my_listings_or_logout:
        click(driver, get_selectors()["listings"]["my_listings"])

    else:
        click(driver, get_selectors()["listings"]["logout"])

def signup(driver, username, oib, firstname, lastname, email, card_number,
           card_type, card_month, card_year, password, password_2):
    type(driver, get_selectors()["signup"]["username"], username)
    type(driver, get_selectors()["signup"]["oib"], oib)
    type(driver, get_selectors()["signup"]["firstname"], firstname)
    type(driver, get_selectors()["signup"]["lastname"], lastname)
    type(driver, get_selectors()["signup"]["email"], email)
    type(driver, get_selectors()["signup"]["card number"],card_number)
    # type(driver, get_selectors()["signup"]["card type"],card_type)
    type(driver, get_selectors()["signup"]["card month"],card_month)
    type(driver, get_selectors()["signup"]["card year"],card_year)
    type(driver, get_selectors()["signup"]["password"], password)
    type(driver, get_selectors()["signup"]["password repeat"], password_2)
    click(driver, get_selectors()["signup"]["confirm"])



if __name__ == '__main__':
    driver = init()

    # home(driver, True)
    # login(driver, "us", "p")


    home(driver, False)
    signup(driver,
           username="mirko123",
           oib="12345678911",
           firstname="mirko",
           lastname="makro",
           email="mirko@gmail.com",
           card_number="5555555555554444",
           card_type="",
           card_month="12",
           card_year="2023",
           password="pass1&Pabc",
           password_2="pass1&Pabc"
           )



