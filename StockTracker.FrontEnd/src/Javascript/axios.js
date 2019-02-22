// in store.js actions
axiosSomething(context) {
		return new Promise((resolve, reject) => {
				axios
						.get(
								`http://axiossomething.please:3001/userinfo`
						)
						.then(
								({ data, status, statusText }) => {
										context.commit("mutateUserInfo", data);
										console.log("Trades:", status, statusText);
										resolve(data);
								},
								error => reject(error)
						);
		});
}