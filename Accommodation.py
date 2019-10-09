class Accommodation:
    def CountAccommodationWaysMemo(self, floorCapacities, noOfPeople):
        floorCapacities.sort(reverse=True)

        dp = [[-1 for _ in range(noOfPeople + 1)] for _ in range(len(floorCapacities))]

        def CountStartAccomodationFrom(floor, noOfPeopleLocal):
            Accommodation._count += 1
            # Solve small sub-problems
            remaining = noOfPeopleLocal - floorCapacities[floor]

            # if remaining < 0: return
            if remaining == 0:
                dp[floor][noOfPeopleLocal] = 1
                return 1

            # Divide & Combine
            levelCount = 0
            for lev in range(floor, len(floorCapacities)):
                if remaining < floorCapacities[lev]: continue

                if dp[lev][remaining] == -1:
                    dp[lev][remaining] = CountStartAccomodationFrom(lev, remaining)
                levelCount += dp[lev][remaining]

            dp[floor][noOfPeopleLocal] = levelCount
            return levelCount

        finalCount = 0
        for level in range(len(floorCapacities)):
            finalCount += CountStartAccomodationFrom(level, noOfPeople)

        return finalCount

    _count = 0

    @staticmethod
    def Work():
        noOfPeople = 5
        floorCapacities = [1, 2, 3]  # Ans: 5  15   9

        accommodationWays = Accommodation().CountAccommodationWaysMemo(floorCapacities, noOfPeople)
        print(accommodationWays)
        print(Accommodation._count)
