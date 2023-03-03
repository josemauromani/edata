<template>
  <section>
    <form @submit.prevent="salvar">
      <div class="field">
        <label for="nome" class="label">Nome</label>
        <input type="text" class="input" id="nome" v-model="nome" required />
      </div>
      <div class="field">
        <label for="nome" class="label">Sobrenome</label>
        <input
          type="text"
          class="input"
          id="sobrenome"
          v-model="sobrenome"
          required
        />
      </div>
      <div class="field">
        <label for="nome" class="label">CPF</label>
        <input type="text" class="input" id="cpf" v-model="cpf" required />
      </div>
      <div class="field">
        <label for="nome" class="label">Data Nascimento</label>
        <input
          type="text"
          class="input"
          id="dataNascimento"
          v-model="dataNascimento"
          required
        />
      </div>
      <div class="field">
        <button class="button" type="submit">Salvar</button>
      </div>
    </form>
  </section>
</template>

<script lang="ts">
import { useStore } from "@/store";
import { defineComponent } from "vue";

import useNotificador from "@/hooks/notificador";
import { ADICIONA_USUARIO, ALTERA_USUARIO } from "@/store/tipo-mutacoes";
import IUsuario from "@/interfaces/IUsuario";
import { TipoNotificacao } from "@/interfaces/INotificacao";

export default defineComponent({
  name: "FormUsuario",
  props: {
    id: {
      type: String,
    },
  },
  data() {
    return {
      nome: "",
      sobrenome: "",
      cpf: "",
      dataNascimento: "",
    };
  },
  methods: {
    salvar() {
      const _usuario = {
        id: this.id ?? new Date().getTime().toString(),
        nome: this.nome,
        sobrenome: this.sobrenome,
        cpf: this.cpf,
        dataNascimento: this.dataNascimento,
      } as IUsuario;

      console.log(_usuario);

      this.id
        ? this.store.dispatch("updateUser",_usuario)
        : this.store.dispatch("addUser", _usuario);

      this.notificar(
        TipoNotificacao.SUCESSO,
        "Sucesso!",
        "Acao realizada com sucesso"
      );
      this.$router.push("/usuarios");
    },
  },
  mounted() {
    if (this.id) {
      const usuario = this.store.state.usuarios.find(
        (_usuario) => _usuario.id == this.id
      );
      this.nome = usuario?.nome || "";
      this.sobrenome = usuario?.sobrenome || "";
      this.cpf = usuario?.cpf || "";
      this.dataNascimento = usuario?.dataNascimento || "";
    }
  },
  setup() {
    const store = useStore();
    const { notificar } = useNotificador();
    return {
      store,
      notificar,
    };
  },
});
</script>
