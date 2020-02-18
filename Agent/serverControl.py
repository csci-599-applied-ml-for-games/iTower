import socket
import threading
import time
import json
import random


tower_list_used = []


def generate_tower_list():

    tower_list = []
    i = 0

    tower_number = 1
    while True:
        # if we exceed the max number of tower
        if i >= tower_number:
            break
        # generate random int first
        tower = {}
        x = random.randint(-5, 5)
        y = random.randint(-4, 4)
        used = False
        for elem in tower_list_used:
            if x == elem['x'] and y == elem['y']:
                used = True
                break
        if not used:
            tower['x'] = x
            tower['y'] = y
            tower['type'] = random.randint(0, 3)
            tower_list.append(tower)
            tower_list_used.append(tower)
            i = i + 1

    return tower_list


TCP_IP = '127.0.0.1'
TCP_PORT = 8081
BUFFER_SIZE = 1024  # Normally 1024, but we want fast response

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

s.bind((TCP_IP, TCP_PORT))
s.listen(1)
print("Server start!")
conn, address = s.accept()
print('Connection address:', address)

# f_tower = open("tower.txt", "w")


def task1():  # receive data
    while True:
        data = conn.recv(BUFFER_SIZE)
        # print(data.decode('utf8'))
        if not data:
            break

        received = data.decode('utf8')
        if 'ok' in received:
            print("received data:", received)
            f_monster = open("monster.txt", "a")
            f_monster.write(received+'\n')
            f_monster.close()
            my_list = generate_tower_list()
            temp = {'tower_list': my_list}
            print(json.dumps(temp))
            f_tower = open("tower.txt", "a")
            f_tower.write(json.dumps(temp)+'\n')
            f_tower.close()
            conn.send(json.dumps(temp).encode('utf8'))
        pass
    # conn.close()
    pass


t1 = threading.Thread(target=task1, name='t1')
t1.start()


# place training model here

