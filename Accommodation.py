class Accommodation:
    def __init__(self, count=0):
        self.count = count

    def CountAccommodationWays(self, floorCapacities, noOfPeople):
        floorCapacities.sort(reverse=True)

        def CountStartAccomodationFrom(floor, noOfPeopleLocal):
            Accommodation._count += 1
            # Solve small sub-problems
            remaining = noOfPeopleLocal - floorCapacities[floor]

            # if remaining < 0: return
            if remaining == 0:
                self.count += 1
                return

            # Divide & Combine
            for lev in range(floor, len(floorCapacities)):
                if remaining < floorCapacities[lev]: continue

                CountStartAccomodationFrom(lev, remaining)

        for level in range(len(floorCapacities)):
            CountStartAccomodationFrom(level, noOfPeople)

        return self.count

    _count = 0

    @staticmethod
    def Work():
        noOfPeople = 5
        floorCapacities = [1, 2, 3]  # Ans: 5  15

        accommodationWays = Accommodation().CountAccommodationWays(floorCapacities, noOfPeople)
        print(accommodationWays)
        print(Accommodation._count)
