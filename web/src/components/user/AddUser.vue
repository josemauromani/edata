<template>
  <div class="submit-form">
    <div v-if="!submitted">
      <div class="form-group">
        <label for="nome">Nome</label>
        <input
          type="text"
          class="form-control"
          id="nome"
          required
          v-model="user.nome"
          name="nome"
        />
      </div>
      <div class="form-group">
        <label for="sobrenome">Sobrenome</label>
        <input
          type="text"
          class="form-control"
          id="sobrenome"
          required
          v-model="user.sobrenome"
          name="sobrenome"
        />
      </div>

      <button>Cadastrar</button>
    </div>
    <div v-else>
      <h4>Cadastro de usuario realizado</h4>
      <button class="btn btn-success" @click="newUser">Cadastrar</button>
    </div>
  </div>
</template>

<script lang="ts">
import UserService from "@/services/UserService";
import User from "@/types/User";
import { defineComponent } from "vue";

export default defineComponent({
  name: "add-user",
  data: () => {
    return {
      user : {
        id: null,
        nome: "",
        sobrenome: "",
      } as User,
      submitted: false,
    };
  },
  methods: {
    saveUser() {
      let data = {
        nome: this.user.nome,
        sobrenome: this.user.sobrenome,
      };

      UserService.create(data)
        .then()
        .catch((e: Error) => {
          console.log(e);
        })
    },
    newUser() {
      this.submitted = false;
      this.user = {} as User;
    }
  }
});
</script>

<style>
.submit-form {
  max-width: 300px;
  margin: auto;
}
input, button {
  margin-top: 10px;
}
</style>