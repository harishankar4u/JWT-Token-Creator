JWT Token Creator API
This API provides a simple and secure way to generate JSON Web Tokens (JWT) for authentication and authorization purposes.
It accepts user credentials or payload data, signs them with a secret key (or private key in case of asymmetric algorithms), and returns a JWT string that can be used by clients to authenticate requests to protected resources.

* Features:-

1- Generates JWTs with customizable payloads

2- Supports standard claims (iss, sub, exp, iat, etc.)

3- Configurable signing algorithms (e.g., HS256, RS256)

4- Secure key management for signing and verification

5- Easy integration with authentication middleware

* Use Cases

1- Issue tokens during login or registration

2- Provide temporary access credentials for APIs

3- Enable stateless authentication between services
