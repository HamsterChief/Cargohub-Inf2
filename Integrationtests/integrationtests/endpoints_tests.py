import requests
import pytest

# Documentation: https://docs.python-requests.org

BASE_URL = "http://localhost:3000"
API_KEY = "a1b2c3d4e5"

#IT auth-get-clients
#The test checks if the api returns a 401 error code when a request is being made without any (valid) api key.
#This tests the security of the API, It is important to make sure that users cannot have access to client data without a valid api key.
def test_auth_get_clients():
    response = requests.get(f"{BASE_URL}/api/v1/clients")
    assert response.status_code == 401

#pytest.mark.run(order=1)

