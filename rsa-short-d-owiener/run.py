import owiener

n = 0x00
e = 0x00

d = owiener.attack(e, n)

if d is None:
    print("Failed")
else:
    print("Hacked d={}".format(d))

    from Crypto.PublicKey import RSA
    from Crypto.Cipher import PKCS1_OAEP
    from base64 import b64decode

    private_key = RSA.construct((n, e, d))
    private_key.exportKey("PEM")
