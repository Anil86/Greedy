class XsquareAndChocolatesBars:
    def CountRemainingCandies(self, bar):
        # def CountDifferentCandiesSets(current):
        #     count = 0
        #     while True:
        #         # Stop condition
        #         if current >= len(bar) - 1: return count
        #
        #         # Greedy choice
        #         if bar[current - 1] == bar[current] and bar[current] == bar[current + 1]:
        #             current += 1
        #         else:
        #             count += 1
        #             current += 3

        def CountDifferentCandiesSets(current):
            # Stop condition
            if current >= len(bar) - 1: return 0

            # Greedy choice
            if bar[current - 1] == bar[current] and bar[current] == bar[current + 1]:
                return CountDifferentCandiesSets(current + 1)

            return 1 + CountDifferentCandiesSets(current + 3)

        differentCandiesSetCount = CountDifferentCandiesSets(1)
        return len(bar) - 3 * differentCandiesSetCount

    @staticmethod
    def Work():
        # bar = "CCCCCCCCC"   # Ans: 9
        # bar = "SSSSCSCCC"  # Ans: 3
        # bar = "SSCCSSSCS"  # Ans: 0
        bar = "CCCSCCSSSCSCCSCSSCSCCCSSCCSCCCSCCSSSCCSCCCSCSCCCSSSCCSSSSCSCCCSCSSCSSSCSSSCSCCCSCSCSCSSSCS"  # Ans:

        remainingCandies = XsquareAndChocolatesBars().CountRemainingCandies(bar)
        print(remainingCandies)
