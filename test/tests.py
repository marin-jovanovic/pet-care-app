"""test suite"""
from ast import literal_eval
import os
import subprocess
import unittest
import requests

import selenium.common.exceptions
from selenium.webdriver.common.by import By

from drivers import init, home, login, get_selectors, listings, signup

class TestMain(unittest.TestCase):

    def get_constants(self):
        return {
            "existing user username": "mata",
            "existing user password": "ma",

            "non existing user username": "fff",
            "non existing user password": "fff",

            "wrong user pass combo text": "Netočna kombinacija korisnika i lozinke",

             "signup_username": "mirko123",
             "signup_oib": "12345678911",
            "signup_firstname": "mirko",
            "signup_lastname": "makro",
            "signup_email": "mirko@gmail.com",
            "signup_card_number": "55555555555",
            "signup_card_type": "",
            "signup_card_month": "12",
            "signup_card_year": "2023",
            "signup_password": "pass1&Pabc",
            "signup_password_2": "pass1&Pabc"
        }

    def test_enter_home(self):
        init()

        self.assertTrue(True)

    def test_enter_login(self):
        driver = init()

        home(driver, True)
        self.assertTrue(True)

    def test_enter_signup(self):
        driver = init()

        home(driver, False)
        self.assertTrue(True)

    def test_enter_listings(self):
        driver = init()

        home(driver, True)
        login(
            driver,
            username=self.get_constants()["existing user username"],
            password=self.get_constants()["existing user password"]
        )
        self.assertTrue(True)

    def test_enter_my_listings(self):
        driver = init()

        home(driver, True)
        login(
            driver,
            username=self.get_constants()["existing user username"],
            password=self.get_constants()["existing user password"]
        )


        self.assertTrue(True)

    def test_enter_edit_first_listing(self):
        self.assertTrue(True)

    def test_wrong_login(self):
        driver = init()

        home(driver, True)
        login(
            driver,
            username=self.get_constants()["non existing user username"],
            password=self.get_constants()["non existing user password"]
        )
        self.assertTrue(True)

        try:
            elem = driver.find_element(by=By.CSS_SELECTOR, value=get_selectors()["login"]["error msg"])
            self.assertEqual(elem.get_attribute("innerText"), get_selectors()["wrong user pass combo text"])

            self.assertTrue(True)

        except selenium.common.exceptions.NoSuchElementException:
            self.assertTrue(False)

    def test_correct_login(self):
        driver = init()

        home(driver, True)
        login(
            driver,
            username=self.get_constants()["existing user username"],
            password=self.get_constants()["existing user password"]
        )
        self.assertTrue(True)

        try:
            driver.find_element(by=By.CSS_SELECTOR, value=get_selectors()["login"]["error msg"])

            self.assertTrue(False)

        except selenium.common.exceptions.NoSuchElementException:
            self.assertTrue(True)

    def test_logout(self):
        driver = init()
        home(driver, True)
        login(
            driver,
            username=self.get_constants()["existing user username"],
            password=self.get_constants()["existing user password"]
        )
        listings(driver, my_listings_or_logout=False)

        try:
            driver.find_element(by=By.CSS_SELECTOR, value=get_selectors()["logout"]["logout content"])

            self.assertTrue(False)

        except selenium.common.exceptions.NoSuchElementException:
            self.assertTrue(True)

    def test_controller_delete_user(self):

        url = 'https://localhost:7213/People/Delete'
        myobj = {'username': self.get_constants()["signup_username"]}

        requests.post(url, data=myobj, verify=False)

    def test_controller_edit_user(self):

        url = 'https://localhost:7213/People/Task'
        myobj = {
            'id': self.get_constants()["signup_username"],
            # "userName": "1",
            # "mobileNumber": "1",
            # "email": "1",
            # "password": "1",
            # # "Title": "f"
        }

        t = requests.get(url, data=myobj, verify=False)
        print(t.text)

        self.assertTrue(True)

    def test_controller_create_user(self):

        url = 'https://localhost:7213/People/Create'
        myobj = {
            'id': self.get_constants()["signup_username"],
            # "userName": "1",
            # "mobileNumber": "1",
            # "email": "1",
            # "password": "1",
            # # "Title": "f"
        }

        t = requests.post(url, data=myobj, verify=False)
        print(t.text)

        self.assertTrue(True)


    def test_failed_signup(self):
        driver = init()
        home(driver, False)

        signup(driver,

               self.get_constants()["signup_username"],
               self.get_constants()["signup_oib"],
               self.get_constants()["signup_firstname"],
               self.get_constants()["signup_lastname"],
               self.get_constants()["signup_email"],
               self.get_constants()["signup_card_number"],
               self.get_constants()["signup_card_type"],
            self.get_constants()["signup_card_month"],
            self.get_constants()["signup_card_year"],
            self.get_constants()["signup_password"],
            self.get_constants()["signup_password_2"]
               )

        try:
            driver.find_element(by=By.CSS_SELECTOR, value=get_selectors()["home"]["user"])

            self.test_controller_delete_user()
            self.assertTrue(False)

        except selenium.common.exceptions.NoSuchElementException:
            self.test_controller_delete_user()
            self.assertTrue(True)




if __name__ == "__main__":
    unittest.main()
