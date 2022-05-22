"""test suite"""
from ast import literal_eval
import os
import subprocess
import unittest

from drivers import init, home, login

class TestMain(unittest.TestCase):

    def test_enter_home(self):
        driver = init()

        self.assertTrue(True)
        # input()

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

        home(driver, False)
        login(driver, username="us", password="p")
        self.assertTrue(True)

    def test_enter_my_listings(self):
        self.assertTrue(True)

    def test_enter_edit_first_listing(self):
        self.assertTrue(True)

    def test_wrong_login(self):
        self.assertTrue(True)

    def test_correct_login(self):
        self.assertTrue(True)




if __name__ == "__main__":
    unittest.main()
