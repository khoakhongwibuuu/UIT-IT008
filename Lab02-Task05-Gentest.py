import random

# Số lượng bộ dữ liệu cần sinh
length = 24

def rnd(min_val, max_val):
    return random.randint(min_val, max_val)

PLACES = ["TPHCM", "HANOI", "CANTHO", "HAIPHONG", "DANANG"]

output_file = "output.txt"

with open(output_file, "w", encoding="utf-8") as f:
    f.write(f"{length}\n")
    for _ in range(length):
        type_ = rnd(1, 3)
        f.write(f"{type_}\n")
        f.write(f"{random.choice(PLACES)}\n")
        f.write(f"{0x989680 * rnd(100, 300)}\n")
        f.write(f"{rnd(35, 225)}\n")

        if type_ == 2:
            f.write(f"{rnd(1, 4)}\n")
            f.write(f"{rnd(2010, 2025)}\n")
        elif type_ == 3:
            f.write(f"{rnd(1, 20)}\n")

print("Done")
